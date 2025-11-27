using Moq;
using Service.Implementations.ModuleSegurityService;
using Service.Interfaces.IModuleSegurityService;
using Utilities.JwtAuthentication;
using Xunit;

namespace Tests.Services
{
    public class JwtAuthenticationServiceTests
    {
        private readonly Mock<IJwtAuthentication> _jwtAuthMock;
        private readonly JwtAuthenticationService _service;

        public JwtAuthenticationServiceTests()
        {
            _jwtAuthMock = new Mock<IJwtAuthentication>();
            _service = new JwtAuthenticationService(_jwtAuthMock.Object);
        }

        // ------------------------------------------------------------
        // Authenticate - Credenciales válidas
        // ------------------------------------------------------------
        [Fact]
        public void Authenticate_ValidCredentials_ReturnsToken()
        {
            // Arrange
            string user = "Maria";
            string password = "123";
            string role = "Admin";
            int userId = 1;

            string expectedToken = "fake-jwt-token";

            _jwtAuthMock
                .Setup(x => x.Authenticate(user, password, role, userId))
                .Returns(expectedToken);

            // Act
            var result = _service.Authenticate(user, password, role, userId);

            // Assert
            Assert.Equal(expectedToken, result);
        }

        // ------------------------------------------------------------
        // Authenticate - Credenciales inválidas
        // ------------------------------------------------------------
        [Fact]
        public void Authenticate_InvalidCredentials_ReturnsNull()
        {
            // Arrange
            string user = "Maria";
            string password = "wrong";
            string role = "Admin";
            int userId = 1;

            _jwtAuthMock
                .Setup(x => x.Authenticate(user, password, role, userId))
                .Returns((string)null);

            // Act
            var result = _service.Authenticate(user, password, role, userId);

            // Assert
            Assert.Null(result);
        }

        // ------------------------------------------------------------
        // EncryptMD5 - Contraseña válida
        // ------------------------------------------------------------
        [Fact]
        public void EncryptMD5_ValidPassword_ReturnsHash()
        {
            // Arrange
            string password = "1234";
            string expectedHash = "5f4dcc3b5aa765d61d8327deb882cf99";

            _jwtAuthMock
                .Setup(x => x.EncryptMD5(password))
                .Returns(expectedHash);

            // Act
            var result = _service.EncryptMD5(password);

            // Assert
            Assert.Equal(expectedHash, result);
        }

        // ------------------------------------------------------------
        // EncryptMD5 - Contraseña nula
        // ------------------------------------------------------------
        [Fact]
        public void EncryptMD5_NullPassword_ReturnsNull()
        {
            // Arrange
            _jwtAuthMock
                .Setup(x => x.EncryptMD5(null))
                .Returns((string)null);

            // Act
            var result = _service.EncryptMD5(null);

            // Assert
            Assert.Null(result);
        }

        // ------------------------------------------------------------
        // RenewToken - Token válido
        // ------------------------------------------------------------
        [Fact]
        public void RenewToken_ValidToken_ReturnsNewToken()
        {
            // Arrange
            string oldToken = "old-token";
            string newToken = "new-token";

            _jwtAuthMock
                .Setup(x => x.RenewToken(oldToken))
                .Returns(newToken);

            // Act
            var result = _service.RenewToken(oldToken);

            // Assert
            Assert.Equal(newToken, result);
        }

        // ------------------------------------------------------------
        // RenewToken - Token inválido
        // ------------------------------------------------------------
        [Fact]
        public void RenewToken_InvalidToken_ReturnsNull()
        {
            // Arrange
            string invalidToken = "invalid-token";

            _jwtAuthMock
                .Setup(x => x.RenewToken(invalidToken))
                .Returns((string)null);

            // Act
            var result = _service.RenewToken(invalidToken);

            // Assert
            Assert.Null(result);
        }
    }
}


