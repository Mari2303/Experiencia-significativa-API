using AutoMapper;
using Entity.Context;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using Repository.Implementations;
using Utilities.Helper;
using Xunit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Repository.Implementations.ModuleBaseRepository;
using Entity.Dtos.ModuleSegurity;
using Entity.Requests.ModuleSegurity;

public class BaseModelRepositoryNegativeTests
{
    public static IEnumerable<object[]> CrudTestData =>
        new List<object[]>
        {
            new object[] { "GetAll" },
            new object[] { "GetById" },
            new object[] { "Save" },
            new object[] { "SaveList" }
         
        };

    [Theory]
    [MemberData(nameof(CrudTestData))]
    public async Task CrudMethods_ShouldThrowException_WhenErrorOccurs(string methodName)
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

        // Aquí forzamos que los métodos del helper y mapper lancen excepción para simular fallo
        helperMock.Setup(h => h.GenerateConsecutiveCode()).ThrowsAsync(new Exception("Error generando código"));
        helperMock.Setup(h => h.ValidateDataImport(It.IsAny<UserDTO>())).ThrowsAsync(new Exception("Error validando datos"));
        helperMock.Setup(h => h.ValidateEntityRelationships(It.IsAny<int>())).ThrowsAsync(new Exception("Error validando relaciones"));
        mapperMock.Setup(m => m.Map<User>(It.IsAny<UserDTO>())).Throws(new Exception("Error en mapeo"));

        // Insertar para métodos que lo requieren (GetById, Update)
        if (methodName != "SaveList" && methodName != "Save")
        {
            // Forzamos guardar normal para tener un registro
            helperMock.Setup(h => h.GenerateConsecutiveCode()).ReturnsAsync("CODE123");
            helperMock.Setup(h => h.ValidateDataImport(It.IsAny<UserDTO>())).ReturnsAsync(true);
            mapperMock.Setup(m => m.Map<User>(It.IsAny<UserDTO>())).Returns(entity);

            await repository.Save(entity);
        }

        // Ejecutar y validar que lance excepción o resultado nulo segun caso
        switch (methodName)
        {
            case "GetAll":

                // Aquí como ejemplo solo hacemos que query falle lanzando excepción si quieres.
                // Pero por simplicidad, no cambiamos internamente el repo.
                await Assert.ThrowsAnyAsync<Exception>(() => repository.GetAll(new QueryFilterRequest { Filter = "throw" }));
                break;




            case "GetById":
                var result = await repository.GetById(-1); // id que no existe
                Assert.Null(result);
                break;

            // prueba unitaria para el método Save de BaseModelRepository cuando hay un error en la validación de datos

            case "Save":
                var entityToSave = new User { State = true };
                await Assert.ThrowsAsync<Exception>(() => repository.Save(entityToSave));
                break;


           

           
             }
        }
    }
