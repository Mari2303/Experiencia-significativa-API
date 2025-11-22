using Entity.Dtos.ModuleSegurity;
using Entity.Models;
using Entity.Requests.ModuleSegurity;
using Service.Interfaces.IModuleBaseService;

namespace Service.Interfaces.IModuleSegurityService
{
    /// <summary>
    /// Interfaz que define las operaciones de servicio relacionadas con los usuarios.
    /// </summary>
    public interface IUserService : IBaseModelService<User, UserDTO, UserRequest>
    {

        /// <summary>
        /// Recupera una entidad específica por su nombre.
        /// </summary>
        /// <param name="name">El nombre de la entidad que se desea recuperar.</param>
        /// <returns>Una tarea que representa la operación asíncrona, conteniendo la entidad si se encuentra.</returns>
        Task<UserRequest?> GetByName(string name);

        /// <summary>
        /// Obtiene el menú asociado a un usuario específico.
        /// </summary>
        /// <param name="userId">El ID del usuario.</param>
        /// <returns>Una tarea que representa la operación asíncrona, devolviendo la lista de elementos del menú.</returns>
        Task<List<MenuRequest>> GetMenuAsync(int userId);

        Task SendRecoveryCodeAsync(string email);
        Task ResetPasswordAsync(string email, string code, string newPassword);

        Task<UserDTO> ActivateAccountAsync(int userId);


    }
}

