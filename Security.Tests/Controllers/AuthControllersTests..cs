using API.Controllers.ModuleSegurityController;
using AutoMapper;
using Entity.Models;
using Entity.Requests.ModuleBase;
using Entity.Requests.ModuleSegurity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Service.Implementations;
using Service.Interfaces.IModuleSegurityService;
using Assert = Xunit.Assert;




namespace Security.Tests.Controllers
{

    public class AuthControllersTests
    {
        private Mock<IAuthService> mockAuthService = null!;
        private Mock<IMapper> _mockmappers = null!;
        private AuthController _controller = null!;


        public void Setap()
        {
            mockAuthService = new Mock<IAuthService>();
            _mockmappers = new Mock<IMapper>();
            _controller = new AuthController(mockAuthService.Object, _mockmappers.Object);

        }

        // prueba unitaria para el metodo LoginAsync del AuthController para el caso exitoso

        [Fact]
        public async Task LoginAsync_ReturnsOk()
        {
            // Arrange
            var mockAuthService = new Mock<IAuthService>();
            var mockMapper = new Mock<IMapper>();
            var controller = new AuthController(mockAuthService.Object, mockMapper.Object);

            var request = new AuthenticationRequest { Username = "user", Password = "1234" };
            var expectedResponse = new UserLoginResponseRequest { Token = "fake-jwt-token" };

            mockAuthService
                .Setup(s => s.LoginAsync(request.Username, request.Password))
                .ReturnsAsync(expectedResponse);

            // Act
            var result = await controller.LoginAsync(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsType<ApiResponseRequest<UserLoginResponseRequest>>(okResult.Value);

            Assert.Equal("Session started successfully", response.Message);
            Assert.Equal("fake-jwt-token", response.Data.Token);
        }


        // prueba unitaria para el metodo LoginAsync del AuthController para el caso de error 500
        [Fact]
        public async Task LoginAsync_Returns500_WhenExceptionIsThrown()
        {
            var mockAuthService = new Mock<IAuthService>();
            var mockMapper = new Mock<IMapper>();

            mockAuthService
                .Setup(s => s.LoginAsync(It.IsAny<string>(), It.IsAny<string>()))
                .ThrowsAsync(new Exception("Test error"));

            // Act
            var controller = new AuthController(mockAuthService.Object, mockMapper.Object);

            // Assert
            var request = new AuthenticationRequest { Username = "fail", Password = "fail" };
            var result = await controller.LoginAsync(request);

            Assert.IsType<ObjectResult>(result);
        }
  


        // prueba unitara para el metodo UpdatePassword del AuthController para el caso exitoso
        [Fact]

        public async Task UpdatePassword_ShouldReturnOk()
        {

            // Arrange
            var dto = new ChangePasswordRequest
            {

                CurrentPassword = "123!",
                NewPassword = "456!"
            };

            var mockAuthService = new Mock<IAuthService>();
            var mockMapper = new Mock<IMapper>();


            mockAuthService
                .Setup(s => s.ChangePasswordAsync(dto))
                .Returns(Task.CompletedTask);
            // Act

            var controller = new AuthController(mockAuthService.Object, mockMapper.Object);
        }


        // prueba unitaria para el metodo UpdatePassword del AuthController para el caso de error 500

        [Fact]

        public async Task UpdatePassword_ShouldReturn500()
        {
            // Arrange
            var dto = new ChangePasswordRequest
            {
                CurrentPassword = "123!",
                NewPassword = "456!"
            };
            var mockAuthService = new Mock<IAuthService>();
            var mockMapper = new Mock<IMapper>();

            mockAuthService
                .Setup(s => s.ChangePasswordAsync(dto))
                .ThrowsAsync(new Exception("Error changing password"));

            // Act
            var controller = new AuthController(mockAuthService.Object, mockMapper.Object);
            var result = await controller.UpdatePassword(dto);

            // Assert
            Assert.IsType<ObjectResult>(result);
        }
      

        // prueba unitaria para el metodo RenewToken del AuthController para el caso exitoso

        [Fact]
        public async Task RenewToken_ReturnsOk()
        {
            // Arrange
            var mockAuthService = new Mock<IAuthService>();
            var mockMapper = new Mock<IMapper>();
            var controller = new AuthController(mockAuthService.Object, mockMapper.Object);

            var fakeOldToken = "fake-jwt-token";
            var expectedResponse = new RenewTokenRequest { Token = "new-fake-jwt-token" };

            // Simular que el servicio devuelve un token renovado
            mockAuthService
                .Setup(s => s.RenewTokenAsync(fakeOldToken))
                .ReturnsAsync(expectedResponse);

            // Simular HttpContext con header Authorization
            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext()
            };
            controller.HttpContext.Request.Headers["Authorization"] = $"Bearer {fakeOldToken}";

            // Act
            var result = await controller.RenewToken();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsType<ApiResponseRequest<RenewTokenRequest>>(okResult.Value);

            Assert.Equal("Token renewed successfully", response.Message);
            Assert.Equal("new-fake-jwt-token", response.Data.Token);
        }

        


        // prueba unitaria para el metodo RenewToken del AuthController para el caso de error 500

        [Fact]
        public async Task RenewToken_ReturnsUnauthorized_WhenHeaderIsMissing()
        {
            // Arrange
            var mockAuthService = new Mock<IAuthService>();
            var mockMapper = new Mock<IMapper>();
            var controller = new AuthController(mockAuthService.Object, mockMapper.Object);

            // Simular HttpContext sin header Authorization
            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext()
            };

            // Act
            var result = await controller.RenewToken();

            // Assert
            var unauthorizedResult = Assert.IsType<UnauthorizedObjectResult>(result);
            var response = Assert.IsType<ApiResponseRequest<string>>(unauthorizedResult.Value);

            
            Assert.Equal("Authorization header is missing or invalid", response.Message);
        }
    }
}




















