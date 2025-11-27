using AutoMapper;
using Entity.Context;
using Entity.Dtos.ModuleSegurity;
using Entity.Models;
using Entity.Models.ModuleSegurity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using Repository.Implementations.ModuleSegurityRepository;
using Utilities.Helper;
using Xunit;

public class UserRepository_EFTests
{
    private IConfiguration BuildConfig()
    {
        var settings = new Dictionary<string, string>();
        return new ConfigurationBuilder().AddInMemoryCollection(settings).Build();
    }

    private ApplicationContext BuildContext(string dbName)
    {
        var options = new DbContextOptionsBuilder<ApplicationContext>()
            .UseInMemoryDatabase(databaseName: dbName)
            .Options;

        return new ApplicationContext(options, BuildConfig());
    }

    private UserRepository BuildRepo(ApplicationContext context)
    {
        var mapper = new Mock<IMapper>();
        var helper = new Mock<IHelper<User, UserDTO>>();

        return new UserRepository(context, mapper.Object, BuildConfig(), helper.Object);
    }

   
    //  AddAsync
  
    [Fact]
    public async Task AddAsync_Should_Add_User()
    {
        var context = BuildContext("u_add");
        var repo = BuildRepo(context);

        var user = new User { Username = "Maria" };

        await repo.AddAsync(user);

        Assert.Equal(1, await context.Users.CountAsync());
        Assert.Equal("Maria", (await context.Users.FirstAsync()).Username);
    }

  
    //  GetRolesByUserId
   
    [Fact]
    public async Task GetRolesByUserId_Should_Return_Roles()
    {
        var context = BuildContext("u_roles");
        var repo = BuildRepo(context);

        // Create Roles
        var roleAdmin = new Role { Id = 1, Name = "Admin" };
        var roleUser = new Role { Id = 2, Name = "User" };

        // Create User
        var user = new User { Id = 10, Username = "TestUser" };

        // Pivot table
        var ur1 = new UserRole { UserId = 10, RoleId = 1, Role = roleAdmin };
        var ur2 = new UserRole { UserId = 10, RoleId = 2, Role = roleUser };

        user.UserRoles = new List<UserRole> { ur1, ur2 };

        context.Users.Add(user);
        context.Roles.AddRange(roleAdmin, roleUser);
        context.UserRoles.AddRange(ur1, ur2);

        await context.SaveChangesAsync();

        var result = await repo.GetRolesByUserId(10);

        Assert.Contains("Admin", result);
        Assert.Contains("User", result);
        Assert.Equal(2, result.Count);
    }

   
    //  GetByEmailAsync
  
    [Fact]
    public async Task GetByEmailAsync_Should_Return_User()
    {
        var context = BuildContext("u_email");
        var repo = BuildRepo(context);

        var person = new Person { Id = 1, Email = "test@mail.com" };
        var user = new User { Id = 1, Username = "Maria", Person = person };

        context.Persons.Add(person);
        context.Users.Add(user);

        await context.SaveChangesAsync();

        var result = await repo.GetByEmailAsync("test@mail.com");

        Assert.NotNull(result);
        Assert.Equal("Maria", result.Username);
    }

    
 

   
    // . GetByIdAsync
   
    [Fact]
    public async Task GetByIdAsync_Should_Return_User()
    {
        var context = BuildContext("u_getid");
        var repo = BuildRepo(context);

        var person = new Person { Id = 5, FirstName = "Maria" };
        var user = new User { Id = 1, Username = "Maria", Person = person };

        context.Persons.Add(person);
        context.Users.Add(user);

        await context.SaveChangesAsync();

        var result = await repo.GetByIdAsync(1);

        Assert.NotNull(result);
        Assert.Equal("Maria", result.Username);
        Assert.NotNull(result.Person);
    }


    //  UpdateTwoFactorAsync
   
    [Fact]
    public async Task UpdateTwoFactorAsync_Should_Update_Code()
    {
        var context = BuildContext("u_2fa");
        var repo = BuildRepo(context);

        var user = new User { Id = 1 };
        context.Users.Add(user);
        await context.SaveChangesAsync();

        await repo.UpdateTwoFactorAsync(1, "9999", DateTime.Today);

        var updated = context.Users.Find(1);

        Assert.Equal("9999", updated.RecoveryCode);
    }


    //  UpdateTwoAsync
   
    [Fact]
    public async Task UpdateTwoAsync_Should_Update_Code()
    {
        var context = BuildContext("u_2");
        var repo = BuildRepo(context);

        var user = new User { Id = 1 };
        context.Users.Add(user);
        await context.SaveChangesAsync();

        await repo.UpdateTwoAsync(1, "ABC", DateTime.Today);

        Assert.Equal("ABC", context.Users.Find(1).RecoveryCode);
    }

  
    //  ClearTwoFactorCodeAsync
 
    [Fact]
    public async Task ClearTwoFactorCodeAsync_Should_Clear_Codes()
    {
        var context = BuildContext("u_clear2fa");
        var repo = BuildRepo(context);

        var user = new User { Id = 1, RecoveryCode = "XYZ", RecoveryCodeExpiration = DateTime.Now };
        context.Users.Add(user);
        await context.SaveChangesAsync();

        await repo.ClearTwoFactorCodeAsync(1);

        var result = context.Users.Find(1);

        Assert.Null(result.RecoveryCode);
        Assert.Null(result.RecoveryCodeExpiration);
    }
}


