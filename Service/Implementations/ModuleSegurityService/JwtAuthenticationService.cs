using Repository.Interfaces;
using Utilities.JwtAuthentication;
using Service.Interfaces.IModuleSegurityService;

namespace Service.Implementations.ModuleSegurityService
{
    /// <summary>
    /// Implementación del servicio de autenticación JWT para generar, validar y renovar tokens JWT.
    /// </summary>
    public class JwtAuthenticationService : IJwtAuthenticationService
    {
        private readonly IJwtAuthentication _jwtAuthentication;

        /// <summary>
        /// Constructor de la clase <see cref="JwtAuthenticationService"/>.
        /// </summary>
        /// <param name="jwtAuthentication">Instancia de la utilidad encargada de manejar la autenticación JWT.</param>
        public JwtAuthenticationService(IJwtAuthentication jwtAuthentication)
        {
            _jwtAuthentication = jwtAuthentication;
           
        }

        /// <summary>
        /// Genera un token JWT si las credenciales proporcionadas son válidas.
        /// </summary>
        /// <param name="user">El nombre de usuario.</param>
        /// <param name="password">La contraseña del usuario.</param>
        /// <param name="role">El rol del usuario.</param>
        /// <param name="userId">El identificador único del usuario.</param>
        /// <returns>Un token JWT si las credenciales son correctas; de lo contrario, <c>null</c>.</returns>
        public string Authenticate(string user, string password, string role, int userId)
        {
            return _jwtAuthentication.Authenticate(user, password, role, userId);
        }

        /// <summary>
        /// Encripta la contraseña proporcionada usando el algoritmo MD5.
        /// </summary>
        /// <param name="password">La contraseña que se desea encriptar.</param>
        /// <returns>La contraseña encriptada en formato de cadena hexadecimal.</returns>
        public string EncryptMD5(string password)
        {
            return _jwtAuthentication.EncryptMD5(password);
        }

        /// <summary>
        /// Renueva un token JWT existente creando uno nuevo con los mismos claims pero con un nuevo tiempo de expiración.
        /// </summary>
        /// <param name="existingToken">El token JWT existente que se desea renovar.</param>
        /// <returns>Un nuevo token JWT con los mismos claims y nuevo tiempo de expiración, 
        /// o un mensaje de error si la renovación falla.</returns>
        public string RenewToken(string existingToken)
        {
            return _jwtAuthentication.RenewToken(existingToken);
        }
    }
}

