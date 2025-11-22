

/*
using Moq;
using Service.Implementations;
using Service.Interfaces;
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



        // prueba unitaria para el método Authenticate de JwtAuthenticationService
        [Fact]
        public void Authenticate_ValidCredentials_ReturnsToken()
        {
            // Arrange
            var user = "Maria";
            var password = "123";
            var expectedToken = "fake-jwt-token";

            _jwtAuthMock
                .Setup(x => x.Authenticate(user, password))
                .Returns(expectedToken);

            // Act
            var result = _service.Authenticate(user, password);

            // Assert
            Assert.Equal(expectedToken, result);
        }

        // prueba unitaria para el método Authenticate de JwtAuthenticationService con credenciales inválidas

        [Fact]
        public void Authenticate_InvalidCredentials_ReturnsNull()
        {
            // Arrange
            var user = "maria";
            var password = "123";

            _jwtAuthMock
                .Setup(x => x.Authenticate(user, password))
                .Returns((string)null);

            // Act
            var result = _service.Authenticate(user, password);

            // Assert
            Assert.Null(result);
        }

        // prueba unitaria para el método EncryptMD5 de JwtAuthenticationService con una contraseña válida

        [Fact]
        public void EncryptMD5_ValidPassword_ReturnsHash()
        {
            // Arrange
            var password = "1234";
            var expectedHash = "5f4dcc3b5aa765d61d8327deb882cf99"; // ejemplo

            _jwtAuthMock
                .Setup(x => x.EncryptMD5(password))
                .Returns(expectedHash);

            // Act
            var result = _service.EncryptMD5(password);

            // Assert
            Assert.Equal(expectedHash, result);
        }

        // prueba unitaria para el método EncryptMD5 de JwtAuthenticationService con una contraseña nula

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

        // prueba unitaria para el método RenewToken de JwtAuthenticationService con un token válido

        [Fact]
        public void RenewToken_ValidToken_ReturnsNewToken()
        {
            // Arrange
            var oldToken = "old-token";
            var newToken = "new-token";

            _jwtAuthMock
                .Setup(x => x.RenewToken(oldToken))
                .Returns(newToken);

            // Act
            var result = _service.RenewToken(oldToken);

            // Assert
            Assert.Equal(newToken, result);
        }

        // prueba unitaria para el método RenewToken de JwtAuthenticationService con un token inválido

        [Fact]
        public void RenewToken_InvalidToken_ReturnsErrorMessage()
        {
            // Arrange
            var oldToken = "invalid-token";

            _jwtAuthMock
                .Setup(x => x.RenewToken(oldToken))
                .Returns((string)null);

            // Act
            var result = _service.RenewToken(oldToken);

            // Assert
            Assert.Null(result);
        }
    }
}

*/