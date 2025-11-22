using AutoMapper;
using Entity.Context;
using Entity.Dtos.ModuleSegurity;
using Entity.Models;
using Entity.Requests.ModuleSegurity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using Repository.Implementations;
using Repository.Implementations.ModuleBaseRepository;
using Utilities.Helper;

public class BaseModelRepositoryTests
{
    public static IEnumerable<object[]> CrudTestData =>
        new List<object[]>
        {
            new object[] { "GetAll" },
            new object[] { "GetById" },
            new object[] { "Save" },
            new object[] { "Update" }
           
        };

    [Theory]
    [MemberData(nameof(CrudTestData))]
    public async Task CrudMethods_ShouldWorkCorrectly(string methodName)
    {
        var inMemorySettings = new Dictionary<string, string> {
        {"Pagination:DefaultPageNumber", "1"},
        {"Pagination:DefaultPageSize", "10"},
        {"Ordering:DefaultColumnOrder", "Id"},
        {"Ordering:DefaultDirectionOrder", "asc"}
    };
        var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(inMemorySettings)
            .Build();

        // Preparar contexto en memoria (DESPUÉS de crear configuration)
        var options = new DbContextOptionsBuilder<ApplicationContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        var context = new ApplicationContext(options, configuration);

        var mapperMock = new Mock<IMapper>();
        var helperMock = new Mock<IHelper<User, UserDTO>>();

        var repository = new BaseModelRepository<User, UserDTO, UserRequest>(
            context,
            mapperMock.Object,
            configuration,
            helperMock.Object
        );

        // Datos de prueba
        var entity = new User { State = true };
        var dto = new UserDTO();

        mapperMock.Setup(m => m.Map<UserRequest>(It.IsAny<User>())).Returns(new UserRequest());
        mapperMock.Setup(m => m.Map<User>(It.IsAny<UserDTO>())).Returns(entity);

        helperMock.Setup(h => h.GenerateConsecutiveCode()).ReturnsAsync("CODE123");
        helperMock.Setup(h => h.ValidateDataImport(It.IsAny<UserDTO>())).ReturnsAsync(true);
        helperMock.Setup(h => h.ValidateEntityRelationships(It.IsAny<int>())).ReturnsAsync(true);

        // Insertar un registro para GetById, Update y Delete
        if (methodName != "SaveList") // para no repetir saveList
        {
            await repository.Save(entity);
        }

        // Ejecutar y validar
        switch (methodName)
        {
            case "GetAll":
                var filters = new QueryFilterRequest { AplyPagination = true };
                var all = await repository.GetAll(filters);
                Assert.NotNull(all);
                break;

            case "GetById":
                var byId = await repository.GetById(entity.Id);
                Assert.NotNull(byId);
                break;

            case "Save":
                var saved = await repository.Save(new User());
                Assert.NotNull(saved);
                Assert.Equal("CODE123", saved.Code);
                break;

           

            case "Update":
                entity.State = false;
                await repository.Update(entity);
                var updated = await context.Set<User>().FindAsync(entity.Id);
                Assert.False(updated.State);
                break;






        }
    }
}











