using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using Utilities.JwtAuthentication;
using Xunit;



using JwtAuthImpl = Utilities.JwtAuthentication.JwtAuthentication;

public class JwtAuthenticationTests
{
    private readonly string _testKey = "Mariaalejanmosquera_henriquez_sena";
    private readonly JwtAuthImpl _jwtAuth;

    public JwtAuthenticationTests()
    {
        _jwtAuth = new JwtAuthImpl(_testKey);



    }
}
    /*

    // prueba unitaria para el método Authenticate de JwtAuthentication
    [Fact]
        public void Authenticate_ReturnsToken()
        {
            // Act
            var token = _jwtAuth.Authenticate("MARIA", "43567");

            // Assert
            Assert.False(string.IsNullOrEmpty(token));

            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);
            Assert.Equal("MARIA", jwtToken.Claims.First(c => c.Type == "unique_name").Value);
        }



    // prueba unitaria para el método Authenticate de JwtAuthentication con credenciales inválidas
    [Fact]
        public void Authenticate_Username_ReturnsNull()
        {
            var token = _jwtAuth.Authenticate("", "43567");
            Assert.Null(token);
        }





    // prueba unitaria para el método Authenticate de JwtAuthentication con contraseña vacía
    [Fact]
        public void Authenticate_ReturnsNull()
        {
            var token = _jwtAuth.Authenticate("MARIA", "");
            Assert.Null(token);
        }



    // prueba unitaria para el método Authenticate de JwtAuthentication con usuario y contraseña vacíos

    [Fact]
        public void EncryptMD5_ReturnsSameHash()
        {
            var hash1 = _jwtAuth.EncryptMD5("12345");
            var hash2 = _jwtAuth.EncryptMD5("12345");
            Assert.Equal(hash1, hash2);
        }



    // prueba unitaria para el método EncryptMD5 de JwtAuthentication con una contraseña válida
    [Fact]
        public void EncryptMD5_ReturnsMD5OfEmpty()
        {
            var hash = _jwtAuth.EncryptMD5("");
            Assert.Equal("D41D8CD98F00B204E9800998ECF8427E", hash);
        }




    // prueba unitaria para el método RenewToken de JwtAuthentication
    [Fact]
        public void RenewToken_ReturnsNewToken()
        {
            // Arrange
            var oldToken = _jwtAuth.Authenticate("MARIA", "43567");

            // Act
            var newToken = _jwtAuth.RenewToken(oldToken);

            // Assert
            Assert.False(string.IsNullOrEmpty(newToken));
           
        }




    // prueba unitaria para el método RenewToken de JwtAuthentication con un token inválido
    [Fact]
        public void RenewToken_InvalidToken_ReturnsErrorMessage()
        {
            var result = _jwtAuth.RenewToken("token_invalido");
            Assert.StartsWith("Failed to renew token:", result);
        }



    // prueba unitaria para el método RenewToken de JwtAuthentication con un token vacío
    [Fact]
        public void RenewToken_ReturnsErrorMessage()
        {
            var result = _jwtAuth.RenewToken("");
            Assert.StartsWith("Failed to renew token:", result);
        }
    }

   */