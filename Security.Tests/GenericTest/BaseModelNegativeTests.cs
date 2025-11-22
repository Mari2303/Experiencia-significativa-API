using API.Controllers;
using API.Controllers.ModuleBaseController;
using AutoMapper;
using Entity.Dtos.ModuleSegurity;
using Entity.Models;
using Entity.Requests.ModuleSegurity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Service.Interfaces.IModuleBaseService;

public class BaseModelTestsNegative
{
    public static IEnumerable<object[]> CrudTestData =>
        new List<object[]>
        {
            new object[] { "GetAll" },
            new object[] { "GetById" },
            new object[] { "Save" },
            new object[] { "Update" },
            new object[] { "Delete" }
        };

    [Theory]
    [MemberData(nameof(CrudTestData))]
    public async Task CrudMethods_ShouldReturnError_WhenExceptionIsThrown(string methodName)
    {
        // Arrange
        var mockService = new Mock<IBaseModelService<User, UserDTO, UserRequest>>();
        var mockMapper = new Mock<IMapper>();

        var controller = new BaseModelController<User, UserDTO, UserRequest>(mockService.Object, mockMapper.Object);

        var entity = new User { Id = 1, Username = "Mari2303" };
        var dto = new UserDTO { Id = 1, Username = "Sebas3406" };

        mockMapper.Setup(m => m.Map<User>(It.IsAny<UserDTO>())).Returns(entity);
        mockMapper.Setup(m => m.Map<UserDTO>(It.IsAny<User>())).Returns(dto);

        // Hacer que el servicio lance excepción en todos los métodos
        mockService.Setup(s => s.GetAll(It.IsAny<QueryFilterRequest>())).ThrowsAsync(new Exception("Error in GetAll"));
        mockService.Setup(s => s.GetById(It.IsAny<int>())).ThrowsAsync(new Exception("Error in GetById"));
        mockService.Setup(s => s.Save(It.IsAny<User>())).ThrowsAsync(new Exception("Error in Save"));
        mockService.Setup(s => s.Update(It.IsAny<User>())).ThrowsAsync(new Exception("Error in Update"));
        mockService.Setup(s => s.Delete(It.IsAny<int>())).ThrowsAsync(new Exception("Error in Delete"));

        // Act & Assert
        switch (methodName)
        {
            case "GetAll":
                var getAllResult = await controller.GetAll(new QueryFilterRequest());
                var objectResultAll = Assert.IsType<ObjectResult>(getAllResult.Result);
                Assert.Equal(500, objectResultAll.StatusCode);
                break;

            case "GetById":
                var getByIdResult = await controller.GetById(1);
                var objectResultById = Assert.IsType<ObjectResult>(getByIdResult.Result);
                Assert.Equal(500, objectResultById.StatusCode);
                break;

            case "Save":
                var saveResult = await controller.Save(dto);
                var objectResultSave = Assert.IsType<ObjectResult>(saveResult.Result);
                Assert.Equal(500, objectResultSave.StatusCode);
                break;


            case "Update":
                var updateResult = await controller.Update(dto);
                var objectResultUpdate = Assert.IsType<ObjectResult>(updateResult.Result);
                Assert.Equal(500, objectResultUpdate.StatusCode);
                break;

            case "Delete":
                var deleteResult = await controller.Delete(1);
                var objectResultDelete = Assert.IsType<ObjectResult>(deleteResult);
                Assert.Equal(500, objectResultDelete.StatusCode);
                break;
        }
    }
}
