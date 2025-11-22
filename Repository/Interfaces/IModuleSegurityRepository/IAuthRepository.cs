using Entity.Models;
using Entity.Requests.ModuleSegurity;

namespace Repository.Interfaces.IModuleSegurityRepository
{
    /// <summary>
    /// Define las operaciones de autenticación y manejo de credenciales de usuario.
    /// </summary>
    public interface IAuthRepository
    {
        /// <summary>
        /// Realiza el inicio de sesión de un usuario validando sus credenciales.
        /// </summary>
        /// <param name="username">El nombre de usuario de la persona que intenta iniciar sesión.</param>
        /// <param name="password">La contraseña del usuario.</param>
        /// <returns>
        /// Una tarea asincrónica que devuelve un objeto <see cref="UserLoginResponseRequest"/> 
        /// con el token JWT y la información del usuario si las credenciales son válidas, 
        /// o un error en caso contrario.
        /// </returns>
        Task<UserLoginResponseRequest> LoginAsync(string username, string password);

        /// <summary>
        /// Cambia la contraseña de un usuario existente.
        /// </summary>
        /// <param name="changePassword">Objeto que contiene el ID del usuario y la nueva contraseña.</param>
        /// <returns>
        /// Una tarea asincrónica que representa la operación de cambio de contraseña.
        /// </returns>
        Task ChangePasswordAsync(ChangePasswordRequest changePassword);

        /// <summary>
        /// Obtiene la información del usuario a partir de un token JWT válido.
        /// </summary>
        /// <param name="token">El token JWT válido que contiene los datos del usuario.</param>
        /// <returns>
        /// Una tarea asincrónica que devuelve el objeto <see cref="User"/> correspondiente al token proporcionado.
        /// </returns>
        Task<User> GetUserFromTokenAsync(string token);

        /// <summary>
        /// Renueva un token JWT existente, creando un nuevo token con los mismos "claims"
        /// pero con una nueva fecha de expiración.
        /// </summary>
        /// <param name="token">El token JWT existente que se desea renovar.</param>
        /// <returns>
        /// Una tarea asincrónica que devuelve un objeto <see cref="RenewTokenRequest"/> 
        /// con la información del nuevo token generado.
        /// </returns>
        Task<RenewTokenRequest> RenewTokenAsync(string token);
    }
}
