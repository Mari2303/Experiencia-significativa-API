using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Service.Interfaces.IModuleBaseService;
using Service.Interfaces.IModuleSegurityService;
using API.Controllers.ModuleSegurityController;
using Entity.Models;
using Entity.Dtos.ModuleSegurity;
using Entity.Requests.ModuleSegurity;
using Entity.Requests.Email;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

public class UserControllerTests
{
    private readonly Mock<IUserService> _userServiceMock;
    private readonly Mock<IBaseModelService<User, UserDTO, UserRequest>> _baseServiceMock;
    private readonly Mock<IMapper> _mapperMock;

    private readonly UserController _controller;

    public UserControllerTests()
    {
        _userServiceMock = new Mock<IUserService>();
        _baseServiceMock = new Mock<IBaseModelService<User, UserDTO, UserRequest>>();
        _mapperMock = new Mock<IMapper>();

        _controller = new UserController(_baseServiceMock.Object, _userServiceMock.Object, _mapperMock.Object);
    }

 

    [Fact]
    public async Task GetByName_UserExists_ReturnsOk()
    {
        // Arrange
        var username = "Maria";

        var userReq = new UserRequest
        {
            Id = 1,
            Username = username
        };

        _userServiceMock.Setup(s => s.GetByName(username))
            .ReturnsAsync(userReq);

        // Act
        var result = await _controller.GetByName(username);

        // Assert
        var ok = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(userReq, ok.Value);
    }

    [Fact]
    public async Task GetByName_UserNotFound_ReturnsNotFound()
    {
        // Arrange
        string username = "NoExiste";

        _userServiceMock.Setup(s => s.GetByName(username))
            .ReturnsAsync((UserRequest)null);

        // Act
        var result = await _controller.GetByName(username);

        // Assert
        Assert.IsType<NotFoundObjectResult>(result);
    }

  

    [Fact]
    public async Task GetMenu_ReturnsOkWithMenu()
    {
        int userId = 5;

        var menu = new List<MenuRequest>
        {
            new MenuRequest(),
            new MenuRequest()
        };

        _userServiceMock.Setup(s => s.GetMenuAsync(userId))
            .ReturnsAsync(menu);

        // Act
        var result = await _controller.GetMenu(userId);

        // Assert
        var ok = Assert.IsType<OkObjectResult>(result.Result);
        Assert.Equal(menu, ok.Value);
    }



    [Fact]
    public async Task ForgotPassword_ReturnsOk()
    {
        var request = new ForgotPasswordRequest { Email = "test@mail.com" };

        _userServiceMock
            .Setup(s => s.SendRecoveryCodeAsync(request.Email))
            .Returns(Task.CompletedTask);

        var result = await _controller.ForgotPassword(request);

        var ok = Assert.IsType<OkObjectResult>(result);
        Assert.Equal("Correo de recuperación enviado.", ok.Value);
    }


    [Fact]
    public async Task ResetPassword_ReturnsOk()
    {
        var request = new ResetPasswordRequest
        {
            Email = "mail@mail.com",
            Code = "12345",
            NewPassword = "newpass"
        };

        _userServiceMock
            .Setup(s => s.ResetPasswordAsync(request.Email, request.Code, request.NewPassword))
            .Returns(Task.CompletedTask);

        var result = await _controller.ResetPassword(request);

        var ok = Assert.IsType<OkObjectResult>(result);
        Assert.Equal("Contraseña actualizada correctamente.", ok.Value);
    }

 

    [Fact]
    public async Task ActivateAccount_Failure_ReturnsBadRequest()
    {
        int userId = 1;

        _userServiceMock.Setup(s => s.ActivateAccountAsync(userId))
            .ThrowsAsync(new System.Exception("Fallo test"));

        var result = await _controller.ActivateAccount(userId);

        var bad = Assert.IsType<BadRequestObjectResult>(result);
        Assert.Contains("Fallo test", bad.Value.ToString());
    }
}


