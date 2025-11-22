using Entity.Models;
using Entity.Requests.ModuleSegurity;

namespace Service.Interfaces.IModuleSegurityService
{
    /// <summary>
    /// Define las operaciones relacionadas con la autenticación de usuarios.
    /// 
    /// Esta interfaz proporciona métodos para:
    /// - Iniciar sesión y obtener un token JWT.
    /// - Cambiar la contraseña del usuario.
    /// - Obtener un usuario a partir de un token JWT.
    /// - Renovar un token existente.
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// Autentica al usuario con las credenciales proporcionadas y genera un token JWT válido.
        /// </summary>
        /// <param name="username">Nombre de usuario utilizado para iniciar sesión.</param>
        /// <param name="password">Contraseña asociada al usuario.</param>
        /// <returns>
        /// Una tarea asincrónica cuyo resultado contiene un <see cref="UserLoginResponseRequest"/> 
        /// con la información del usuario autenticado y el token JWT.
        /// </returns>
        Task<UserLoginResponseRequest> LoginAsync(string username, string password);

        /// <summary>
        /// Cambia la contraseña de un usuario existente.
        /// </summary>
        /// <param name="changePassword">
        /// Objeto de tipo <see cref="ChangePasswordRequest"/> que contiene el ID del usuario y la nueva contraseña.
        /// </param>
        /// <returns>
        /// Una tarea asincrónica que representa la operación. 
        /// No devuelve valor, pero lanza excepciones en caso de error (ej. credenciales inválidas).
        /// </returns>
        Task ChangePasswordAsync(ChangePasswordRequest changePassword);

        /// <summary>
        /// Obtiene un usuario a partir de un token JWT válido.
        /// </summary>
        /// <param name="token">El token JWT utilizado para identificar al usuario.</param>
        /// <returns>
        /// Una tarea asincrónica cuyo resultado es un objeto <see cref="User"/> correspondiente al token proporcionado.
        /// </returns>
        Task<User> GetUserFromTokenAsync(string token);

        /// <summary>
        /// Renueva un token JWT existente, generando uno nuevo con los mismos claims 
        /// pero con una fecha de expiración actualizada.
        /// </summary>
        /// <param name="token">El token JWT que se desea renovar.</param>
        /// <returns>
        /// Una tarea asincrónica cuyo resultado es un objeto <see cref="RenewTokenRequest"/> 
        /// que contiene el nuevo token renovado y su fecha de expiración.
        /// </returns>
        Task<RenewTokenRequest> RenewTokenAsync(string token);


    }
}

