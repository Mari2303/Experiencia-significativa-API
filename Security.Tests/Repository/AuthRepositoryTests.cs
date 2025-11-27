using Moq;
using Xunit;
using Entity.Models;
using Utilities.JwtAuthentication;
using Microsoft.Extensions.Configuration;
using Repository.Implementations.ModuleSegurityRepository;
using Repository.Interfaces.IModuleSegurityRepository;
using Entity.Requests.ModuleSegurity;

public class AuthRepositoryTests
{
    private readonly Mock<IUserRepository> _mockUserRepository;
    private readonly Mock<IJwtAuthentication> _mockJwtAuth;
    private readonly Mock<IConfiguration> _mockConfiguration;
    private readonly AuthRepository _authRepository;

    public AuthRepositoryTests()
    {
        _mockUserRepository = new Mock<IUserRepository>();
        _mockJwtAuth = new Mock<IJwtAuthentication>();
        _mockConfiguration = new Mock<IConfiguration>();

        _authRepository = new AuthRepository(
            _mockConfiguration.Object,
            _mockUserRepository.Object,
            _mockJwtAuth.Object
        );
    }

   
    [Fact]
    public async Task LoginAsync_Success_ReturnsUserLoginResponse()
    {
        string username = "Maria";
        string password = "1234";
        string encrypted = "MD5PASS";

        _mockJwtAuth.Setup(j => j.EncryptMD5(password)).Returns(encrypted);

        _mockUserRepository.Setup(u => u.GetByName(username))
            .ReturnsAsync(new UserRequest
            {
                Id = 1,
                Username = username,
                Password = encrypted,
                Person = "Maria",
                PersonId = 10,
                State = true
            });

        _mockUserRepository.Setup(u => u.GetRolesByUserId(1))
            .ReturnsAsync(new List<string> { "Admin" });

        _mockJwtAuth.Setup(j => j.Authenticate(username, encrypted, "Admin", 1))
            .Returns("FAKE_TOKEN");

        _mockUserRepository.Setup(u => u.GetMenuAsync(1))
            .ReturnsAsync(new List<MenuRequest>
            {
                new MenuRequest(), new MenuRequest()
            });

        var result = await _authRepository.LoginAsync(username, password);

        Assert.NotNull(result);
        Assert.Equal("FAKE_TOKEN", result.Token);
        Assert.Equal("Maria", result.UserName);
        Assert.Equal(1, result.UserId);
    }

   
    [Fact]
    public async Task LoginAsync_Throws_WhenUsernameEmpty()
    {
        var ex = await Assert.ThrowsAsync<Exception>(() =>
            _authRepository.LoginAsync("", "1234"));

        Assert.Equal("El nombre de usuario está vacío.", ex.Message);
    }

   
    [Fact]
    public async Task LoginAsync_Throws_WhenPasswordEmpty()
    {
        var ex = await Assert.ThrowsAsync<Exception>(() =>
            _authRepository.LoginAsync("Maria", ""));

        Assert.Equal("La contraseña está vacía.", ex.Message);
    }



    [Fact]
    public async Task LoginAsync_Throws_WhenPasswordIncorrect()
    {
        _mockJwtAuth.Setup(j => j.EncryptMD5("1234"))
            .Returns("HASHED");

        _mockUserRepository.Setup(u => u.GetByName("Maria"))
            .ReturnsAsync(new UserRequest
            {
                Id = 1,
                Username = "Maria",
                Password = "OTHER_HASH",   // No coincide
                State = true
            });

        var ex = await Assert.ThrowsAsync<Exception>(() =>
            _authRepository.LoginAsync("Maria", "1234"));

        Assert.Equal("Contraseña incorrecta.", ex.Message);
    }

    
    [Fact]
    public async Task LoginAsync_Throws_WhenUserInactive()
    {
        _mockJwtAuth.Setup(j => j.EncryptMD5("1234")).Returns("HASH");

        _mockUserRepository.Setup(u => u.GetByName("Maria"))
            .ReturnsAsync(new UserRequest
            {
                Id = 1,
                Username = "Maria",
                Password = "HASH",
                State = false
            });

        var ex = await Assert.ThrowsAsync<Exception>(() =>
            _authRepository.LoginAsync("Maria", "1234"));

        Assert.Equal("La cuenta está inactiva. Contacte con el administrador.", ex.Message);
    }


  



    [Fact]
    public async Task ChangePasswordAsync_Throws_UserNotFound()
    {
        _mockUserRepository.Setup(u => u.GetById(1))
            .ReturnsAsync((User)null);

        var dto = new ChangePasswordRequest { UserId = 1 };

        var ex = await Assert.ThrowsAsync<Exception>(() =>
            _authRepository.ChangePasswordAsync(dto));

        Assert.Equal("El usuario no existe.", ex.Message);
    }


    [Fact]
    public async Task ChangePasswordAsync_Throws_PasswordsDoNotMatch()
    {
        _mockUserRepository.Setup(u => u.GetById(1))
            .ReturnsAsync(new User { Id = 1, Password = "HASH" });

        _mockJwtAuth.Setup(j => j.EncryptMD5("actual"))
            .Returns("HASH");

        var dto = new ChangePasswordRequest
        {
            UserId = 1,
            CurrentPassword = "actual",
            NewPassword = "uno",
            ConfirmPassword = "dos"
        };

        var ex = await Assert.ThrowsAsync<Exception>(() =>
            _authRepository.ChangePasswordAsync(dto));

        Assert.Equal("Las contraseñas no coinciden.", ex.Message);
    }

}

