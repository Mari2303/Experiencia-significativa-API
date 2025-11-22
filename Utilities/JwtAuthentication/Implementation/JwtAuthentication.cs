using Entity.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Utilities.JwtAuthentication
{
    /// <summary>
    /// Implementación del repositorio de autenticación JWT para generar y validar tokens JWT.
    /// Este servicio es responsable de la autenticación de usuarios mediante JWT y del cifrado de contraseñas con MD5.
    /// </summary>
    public class JwtAuthentication : IJwtAuthentication
    {
        private readonly string _key;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="JwtAuthentication"/>.
        /// </summary>
        /// <param name="key">La clave secreta utilizada para firmar el token JWT.</param>
        public JwtAuthentication(string key)
        {
            this._key = key;
        }

        /// <summary>
        /// Autentica a un usuario generando un token JWT si el nombre de usuario y la contraseña son válidos.
        /// </summary>
        /// <param name="user">El nombre de usuario del usuario.</param>
        /// <param name="password">La contraseña del usuario.</param>
        /// <param name="role">El rol del usuario.</param>
        /// <param name="userId">El ID del usuario.</param>
        /// <returns>Un token JWT si las credenciales son válidas; de lo contrario, null.</returns>
        public string Authenticate(string user, string password, string role, int userId)
        {
            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(password))
                return null!;

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(this._key);

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("id", userId.ToString()),
                    new Claim(ClaimTypes.Name, user),
                    new Claim(ClaimTypes.Role, role)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescription);
            return tokenHandler.WriteToken(token);
        }

        /// <summary>
        /// Cifra una contraseña utilizando el algoritmo de hash MD5.
        /// </summary>
        /// <param name="password">La contraseña a cifrar.</param>
        /// <returns>El hash MD5 de la contraseña como cadena hexadecimal.</returns>
        public string EncryptMD5(string password)
        {
            using (var md5Hash = MD5.Create())
            {
                // Representación en bytes de la cadena
                var sourceBytes = Encoding.UTF8.GetBytes(password);

                // Genera el hash (array de bytes) para los datos de entrada
                var hashBytes = md5Hash.ComputeHash(sourceBytes);

                // Convierte el array de bytes del hash a cadena
                var hash = BitConverter.ToString(hashBytes).Replace("-", string.Empty);
                return hash;
            }
        }

        /// <summary>
        /// Renueva un token JWT existente creando un nuevo token con los mismos claims pero con una nueva fecha de expiración.
        /// </summary>
        /// <param name="existingToken">El token JWT existente que se desea renovar.</param>
        /// <returns>Un nuevo token JWT con los mismos claims pero con nueva fecha de expiración, o un mensaje de error si la renovación falla.</returns>
        public string RenewToken(string existingToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(this._key);

            try
            {
                var jwtToken = tokenHandler.ReadJwtToken(existingToken);

                // Obtiene los claims del token existente
                var claims = jwtToken.Claims;

                // Crea un nuevo token con los mismos claims pero con nueva fecha de expiración
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.UtcNow.AddHours(2),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
                };

                var newToken = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(newToken);
            }
            catch (Exception ex)
            {
                return $"Error al renovar el token: {ex.Message}";
            }
        }
    }
}
