/*using Moq;
using Xunit;
using Entity.Models;
using Utilities.JwtAuthentication;
using Microsoft.Extensions.Configuration;
using Repository.Implementations.ModuleSegurityRepository;
using Repository.Interfaces.IModuleSegurityRepository;
using Entity.Requests.ModuleSegurity;

public class AuthRepositoryTests
{
    private readonly Mock<IUserRepository> _mockuserRepository;
    private readonly Mock<IJwtAuthentication> _mockjwtAuth;
    private readonly Mock<IConfiguration> _mockconfiguration;
    private readonly AuthRepository _authRepository;

    public AuthRepositoryTests()
    {
        _mockuserRepository = new Mock<IUserRepository>();
        _mockjwtAuth = new Mock<IJwtAuthentication>();
        _mockconfiguration = new Mock<IConfiguration>();

       _authRepository = new AuthRepository(
            _mockconfiguration.Object,
            _mockuserRepository.Object,
            _mockjwtAuth.Object
        );
    }

    /*

    // prueba unitaria para el método LoginAsync de AuthRepository

    [Fact]
    public async Task LoginAsync_UserLoginResponse()
    {
        // Arrange
        var username = "Mari2345";
        var password = "password123";
        var encryptedPass = "MD5PASS";

        _mockjwtAuth.Setup(j => j.EncryptMD5(password)).Returns(encryptedPass);
        _mockuserRepository.Setup(u => u.GetByName(username))
            .ReturnsAsync(new UserRequest
            {
                Id = 1,
                Username = username,
                Password = encryptedPass,
                Person = "Test Person",
                PersonId = 2
            });

        _mockjwtAuth.Setup(j => j.Authenticate(username, encryptedPass)).Returns("FAKE_TOKEN");

        _mockuserRepository
       .Setup(u => u.GetMenuAsync(1))
       .ReturnsAsync(new List<MenuRequest>
      {
        new MenuRequest (),
        new MenuRequest ()

      });

        // Act
        var result = await _authRepository.LoginAsync(username, password);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("FAKE_TOKEN", result.Token);
        Assert.Equal("Test Person", result.UserName);
    }

    */


    // prueba unitaria para el método LoginAsync de AuthRepository con username vacío

  /*  [Fact]
    public async Task LoginAsync_UsernameIsEmpty()
    {
        // Act & Assert
        var ex = await Assert.ThrowsAsync<Exception>(() => _authRepository.LoginAsync("", "4567"));
        Assert.Equal("Empty username", ex.Message);
    }



    // prueba unitaria para el método LoginAsync de AuthRepository con password vacío
    [Fact]
    public async Task LoginAsync_PasswordIsEmpty()
    {
        // Act & Assert
        var ex = await Assert.ThrowsAsync<Exception>(() => _authRepository.LoginAsync("mar", ""));
        Assert.Equal("Empty password", ex.Message);
    }



    // prueba unitaria para el método LoginAsync de AuthRepository cuando el usuario no existe
    [Fact]
    public async Task LoginAsync_UserDoesNotExist()
    {
        _mockjwtAuth.Setup(j => j.EncryptMD5(It.IsAny<string>())).Returns("MD5PASS");
        _mockuserRepository.Setup(u => u.GetByName(It.IsAny<string>())).ReturnsAsync((UserRequest)null);

        var ex = await Assert.ThrowsAsync<Exception>(() => _authRepository.LoginAsync("mar", "4567"));
        Assert.Equal("The user does not exist", ex.Message);
    }



    // prueba unitaria para el método LoginAsync de AuthRepository cuando la contraseña es incorrecta
    [Fact]
    public async Task LoginAsync_PasswordIsIncorrect()
    {
        _mockjwtAuth.Setup(j => j.EncryptMD5("4567")).Returns("ENCRYPTED");
        _mockuserRepository.Setup(u => u.GetByName("mar")).ReturnsAsync(new UserRequest
        {
            Id = 1,
            Username = "mar",
            Password = "4567",
            Person = "Test",
            PersonId = 1
        });

        var ex = await Assert.ThrowsAsync<Exception>(() => _authRepository.LoginAsync("mar", "4567"));
        Assert.Equal("Incorrect password", ex.Message);
    }



    // prueba unitaria para el método ChangePasswordAsync de AuthRepository

    [Fact]
    public async Task ChangePasswordAsync_UpdatePassword()
    {
        var user = new User { Id = 1, Password = "OLD" };
        _mockuserRepository.Setup(u => u.GetById(1)).ReturnsAsync(user);
        _mockjwtAuth.Setup(j => j.EncryptMD5("holis123")).Returns("NEW_HASH");

        var dto = new ChangePasswordRequest
        {
            UserId = 1,
            NewPassword = "holis123",
            ConfirmPassword = "holis123"
        };

        await _authRepository.ChangePasswordAsync(dto);

        _mockuserRepository.Verify(u => u.Update(It.Is<User>(usr => usr.Password == "NEW_HASH")), Times.Once);
    }



    // prueba unitaria para el método ChangePasswordAsync de AuthRepository cuando el usuario no existe

    [Fact]
    public async Task ChangePasswordAsync_UserNotFound()
    {
        _mockuserRepository.Setup(u => u.GetById(1)).ReturnsAsync((User)null);

        var dto = new ChangePasswordRequest
        {
            UserId = 1,
            NewPassword = "holis123",
            ConfirmPassword = "holis123"
        };

        var ex = await Assert.ThrowsAsync<Exception>(() => _authRepository.ChangePasswordAsync(dto));
        Assert.Equal("User does not exist", ex.Message);
    }



    // prueba unitaria para el método ChangePasswordAsync de AuthRepository cuando las contraseñas no coinciden

    [Fact]
    public async Task ChangePasswordAsync_PasswordsDoNotMatch()
    {
        _mockuserRepository.Setup(u => u.GetById(1)).ReturnsAsync(new User { Id = 1 });

        var dto = new ChangePasswordRequest
        {
            UserId = 1,
            NewPassword = "holis123",
            ConfirmPassword = "mejor456"
        };

        var ex = await Assert.ThrowsAsync<Exception>(() => _authRepository.ChangePasswordAsync(dto));
        Assert.Equal("Passwords do not match", ex.Message);
    }
}*/
