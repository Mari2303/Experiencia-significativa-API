using Entity.Dtos;
using Entity.Models;
using Entity.Requests.ModuleSegurity;
using Repository.Interfaces.IModuleSegurityRepository;
using Service.Interfaces.IModuleSegurityService;

namespace Service.Implementations.ModuleSegurityService
{
    /// <summary>
    /// Implementación del servicio de autenticación.
    /// 
    /// Esta clase gestiona las operaciones principales relacionadas con:
    /// - Inicio de sesión de usuarios.
    /// - Cambio de contraseña.
    /// - Obtención de un usuario a partir de un token JWT.
    /// - Renovación de tokens JWT.
    /// 
    /// Internamente, delega la lógica de acceso a datos al repositorio de autenticación (<see cref="IAuthRepository"/>).
    /// </summary>
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authrepository;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="AuthService"/>.
        /// </summary>
        /// <param name="authrepository">
        /// Una implementación de <see cref="IAuthRepository"/> que gestiona la lógica de autenticación en la capa de persistencia.
        /// </param>
        public AuthService(IAuthRepository authrepository)
        {
            _authrepository = authrepository;
        }

        /// <summary>
        /// Autentica al usuario con las credenciales proporcionadas y genera un token JWT válido.
        /// </summary>
        /// <param name="username">Nombre de usuario utilizado para iniciar sesión.</param>
        /// <param name="password">Contraseña asociada al usuario.</param>
        /// <returns>
        /// Una tarea asincrónica cuyo resultado es un <see cref="UserLoginResponseRequest"/> 
        /// con la información del usuario autenticado y el token JWT.
        /// </returns>
        public async Task<UserLoginResponseRequest> LoginAsync(string username, string password)
        {
            return await _authrepository.LoginAsync(username, password);
        }

        /// <summary>
        /// Cambia la contraseña de un usuario existente.
        /// </summary>
        /// <param name="request">
        /// Objeto de tipo <see cref="ChangePasswordRequest"/> que contiene el ID del usuario y la nueva contraseña.
        /// </param>
        /// <returns>
        /// Una tarea asincrónica que representa la operación de cambio de contraseña.
        /// </returns>
        public async Task ChangePasswordAsync(ChangePasswordRequest request)
        {
            await _authrepository.ChangePasswordAsync(request);
        }

        /// <summary>
        /// Obtiene un usuario a partir de un token JWT válido.
        /// </summary>
        /// <param name="token">El token JWT utilizado para identificar al usuario.</param>
        /// <returns>
        /// Una tarea asincrónica cuyo resultado es un objeto <see cref="User"/> correspondiente al token proporcionado.
        /// </returns>
        public async Task<User> GetUserFromTokenAsync(string token)
        {
            return await _authrepository.GetUserFromTokenAsync(token);
        }

        /// <summary>
        /// Renueva un token JWT existente, generando uno nuevo con los mismos claims 
        /// pero con una fecha de expiración actualizada.
        /// </summary>
        /// <param name="token">El token JWT que se desea renovar.</param>
        /// <returns>
        /// Una tarea asincrónica cuyo resultado es un objeto <see cref="RenewTokenRequest"/> 
        /// que contiene el nuevo token renovado y sus detalles de expiración.
        /// </returns>
        public async Task<RenewTokenRequest> RenewTokenAsync(string token)
        {
            return await _authrepository.RenewTokenAsync(token);
        }







    }
}

