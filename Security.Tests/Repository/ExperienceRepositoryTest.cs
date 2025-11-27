using AutoMapper;
using Entity.Context;
using Entity.Dtos.ModuleOperational;
using Entity.Models.ModuleOperation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using Repository.Implementations.ModuleOperationRepository;
using Utilities.Helper;

namespace Tests.Repository
{
    public class ExperienceRepositoryTests
    {
     

        private IConfiguration BuildConfig()
        {
            var data = new Dictionary<string, string>();
            return new ConfigurationBuilder().AddInMemoryCollection(data).Build();
        }

        private ApplicationContext BuildContext(string dbName)
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .EnableSensitiveDataLogging()
                .Options;

            return new ApplicationContext(options, BuildConfig());
        }

        private ExperienceRepository BuildRepository(ApplicationContext ctx)
        {
            var mapper = new Mock<IMapper>();
            var helper = new Mock<IHelper<Experience, ExperienceDTO>>();

            return new ExperienceRepository(
                ctx,
                mapper.Object,
                helper.Object,
                BuildConfig()
            );
        }


      

        [Fact]
        public async Task AddAsync_Should_Add_Experience()
        {
            var ctx = BuildContext("add_exp");
            var repo = BuildRepository(ctx);

            var exp = new Experience
            {
                Id = 1,
                NameExperiences = "Nueva experiencia",
                Developmenttime = DateTime.UtcNow.ToString("o"),  
                State = true                        
            };

            await repo.AddAsync(exp);

            var saved = await ctx.Experiences.FindAsync(1);

            Assert.NotNull(saved);
            Assert.Equal("Nueva experiencia", saved.NameExperiences);
        }


      

        [Fact]
        public async Task GetByIdAsync_Should_Return_Experience()
        {
            var ctx = BuildContext("get_by_id");
            var repo = BuildRepository(ctx);

            ctx.Experiences.Add(new Experience
            {
                Id = 5,
                NameExperiences = "Test",
                Developmenttime = DateTime.UtcNow.ToString("o"),   
                State = true                         
            });

            await ctx.SaveChangesAsync();

            var result = await repo.GetByIdAsync(5);

            Assert.NotNull(result);
            Assert.Equal("Test", result.NameExperiences);
        }


     

        [Fact]
        public async Task GetAllAsync_Should_Return_All()
        {
            var ctx = BuildContext("get_all");
            var repo = BuildRepository(ctx);

            ctx.Experiences.AddRange(
                new Experience
                {
                    Id = 1,
                    Developmenttime = DateTime.UtcNow.ToString("o"), 
                    NameExperiences = "A"
                },
                new Experience
                {
                    Id = 2,
                    Developmenttime = DateTime.UtcNow.ToString("o"), 
                    NameExperiences = "B"
                }
            );
            await ctx.SaveChangesAsync();

            var all = await repo.GetAllAsync();

            Assert.Equal(2, all.Count());
        }


      

        [Fact]
        public async Task GetByUserIdAsync_Should_Return_Only_Matching_User()
        {
            var ctx = BuildContext("get_user");
            var repo = BuildRepository(ctx);

            ctx.Experiences.AddRange(
                new Experience
                {
                    Id = 1,
                    UserId = 10,
                    Developmenttime = DateTime.UtcNow.ToString("o"),
                },
                new Experience
                {
                    Id = 2,
                    UserId = 10,
                    Developmenttime = DateTime.UtcNow.ToString("o"),
                },
                new Experience
                {
                    Id = 3,
                    UserId = 99,
                    Developmenttime = DateTime.UtcNow.ToString("o"),
                }
            );

            await ctx.SaveChangesAsync();

            var list = await repo.GetByUserIdAsync(10);

            Assert.Equal(2, list.Count());
        }


      

        [Fact]
        public async Task UpdateAsync_Should_Update_Entity()
        {
            var ctx = BuildContext("update_exp");
            var repo = BuildRepository(ctx);

            var exp = new Experience
            {
                Id = 1,
                NameExperiences = "Old",
                Developmenttime = DateTime.UtcNow.ToString("o"),
                State = true                   
            };

            ctx.Experiences.Add(exp);
            await ctx.SaveChangesAsync();

            exp.NameExperiences = "Updated";
            await repo.UpdateAsync(exp);

            var updated = await ctx.Experiences.FindAsync(1);

            Assert.Equal("Updated", updated.NameExperiences);
        }


       

        [Fact]
        public async Task GetByIdWithDetailsAsync_Should_Return_Null_If_Not_Found()
        {
            var ctx = BuildContext("details_exp");
            var repo = BuildRepository(ctx);

            var result = await repo.GetByIdWithDetailsAsync(999);

            Assert.Null(result);
        }

      

        [Fact]
        public async Task GetDetailByIdAsync_Should_Return_Null_If_Not_Active()
        {
            var ctx = BuildContext("detail_state_exp");
            var repo = BuildRepository(ctx);

            ctx.Experiences.Add(new Experience
            {
                Id = 50,
                NameExperiences = "X",
                State = false,

               
                Developmenttime = DateTime.UtcNow.ToString("o")
            });

            await ctx.SaveChangesAsync();

            var result = await repo.GetDetailByIdAsync(50);

            Assert.Null(result);
        }

    }
}


