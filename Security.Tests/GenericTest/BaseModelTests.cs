using API.Controllers;
using API.Controllers.ModuleBaseController;
using AutoMapper;
using Entity.Dtos.ModuleSegurity;
using Entity.Models;
using Entity.Requests.ModuleSegurity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Service.Interfaces.IModuleBaseService;


/// Pruebas unitarias para un controlador genérico 
/// Este test usa datos parametrizados para cubrir todos los métodos en una sola estructura de prueba.

public class BaseModelTests
{
    /// <summary>
    /// Lista de nombres de métodos  a probar.
    /// Cada elemento será pasado como parámetro a la prueba principal.
    /// </summary>
    
    public static IEnumerable<object[]> CrudTestData =>
        new List<object[]>
        {
            new object[] { "GetAll" },
            new object[] { "GetById" },
            new object[] { "Save" },
            new object[] { "Update" },
            new object[] { "Delete" }
        };

    /// <summary>
    /// Prueba unificada para todos los métodos  del controlador.
    /// Usa [Theory] y [MemberData] para ejecutar la misma prueba con diferentes escenarios.
    /// </summary>
    /// <param name="methodName">Nombre del método  a probar.</param>
    
    [Theory]
    [MemberData(nameof(CrudTestData))]
    public async Task CrudMethods_ShouldReturnOk(string methodName)
    {
        // Arrange signifca que se preparan los datos y objetos necesarios para la prueba

        // Mock del servicio genérico (simula la lógica de negocio)
        var mockService = new Mock<IBaseModelService<User, UserDTO, UserRequest>>();
        // Mock del mapper (simula la conversión entre entidades y DTOs)
        var mockMapper = new Mock<IMapper>();

        // Crear instancia del controlador genérico usando mocks
        var controller = new BaseModelController<User, UserDTO, UserRequest>(mockService.Object, mockMapper.Object);

        // Datos de ejemplo
        var entity = new User { Id = 1, Username = "Mari2303" };
        var dto = new UserDTO { Id = 1, Username = "Sebas3406" };

        // Configuración de AutoMapper simulado
        mockMapper.Setup(m => m.Map<User>(It.IsAny<UserDTO>())).Returns(entity);
        mockMapper.Setup(m => m.Map<UserDTO>(It.IsAny<User>())).Returns(dto);


        // Configuración del servicio simulado para cada método
        mockService.Setup(s => s.GetAll(It.IsAny<QueryFilterRequest>())).ReturnsAsync(new List<UserRequest>());
        mockService.Setup(s => s.GetById(It.IsAny<int>())).ReturnsAsync(entity);
        mockService.Setup(s => s.Save(It.IsAny<User>())).ReturnsAsync(entity);
        mockService.Setup(s => s.Update(It.IsAny<User>())).Returns(Task.CompletedTask);
        mockService.Setup(s => s.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);

        // Act & Assert - Ejecuta el método  y verifica el resultado esperado
        switch (methodName)
        {
            case "GetAll":
                var getAllResult = await controller.GetAll(new QueryFilterRequest());
                Assert.IsType<OkObjectResult>(getAllResult.Result);
                break;

            case "GetById":
                var getByIdResult = await controller.GetById(1);
                Assert.IsType<OkObjectResult>(getByIdResult.Result);
                break;

            case "Save":
                var saveResult = await controller.Save(dto);
                Assert.IsType<CreatedAtRouteResult>(saveResult.Result);
                break;

            case "Update":
                var updateResult = await controller.Update(dto);
                Assert.IsType<OkObjectResult>(updateResult.Result);
                break;

            case "Delete":
                var deleteResult = await controller.Delete(1);
                Assert.IsType<OkObjectResult>(deleteResult);
                break;
        }
    }

    
}
