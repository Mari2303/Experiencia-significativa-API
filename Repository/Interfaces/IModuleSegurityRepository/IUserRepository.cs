using Entity.Dtos.ModuleSegurity;
using Entity.Models;
using Entity.Requests.ModuleSegurity;
using Repository.Interfaces.IModuleBaseRepository;

namespace Repository.Interfaces.IModuleSegurityRepository
{
    /// <summary>
    /// Interfaz para operaciones relacionadas con usuarios.
    /// Esta interfaz define métodos para obtener, agregar, eliminar y actualizar usuarios en el repositorio.
    /// </summary>
    public interface IUserRepository : IBaseModelRepository<User, UserDTO, UserRequest>
    {
        /// <summary>
        /// Obtiene un usuario por su nombre.
        /// </summary>
        /// <param name="name">El nombre del usuario.</param>
        /// <returns>Una tarea que representa la operación asíncrona, con un resultado de tipo <see cref="UserRequest"/> si se encuentra.</returns>
        Task<UserRequest?> GetByName(string name);

        /// <summary>
        /// Obtiene los menús a los que tiene acceso un usuario específico.
        /// </summary>
        /// <param name="userId">El ID del usuario.</param>
        /// <returns>Una tarea que representa la operación asíncrona, con una lista de <see cref="MenuRequest"/> que representa los menús accesibles.</returns>
        Task<List<MenuRequest>> GetMenuAsync(int userId);

        /// <summary>
        /// Agrega un usuario de manera asíncrona.
        /// </summary>
        /// <param name="entity">La entidad de usuario a agregar.</param>
        Task AddAsync(User entity);

        /// <summary>
        /// Obtiene los roles asociados a un usuario por su ID.
        /// </summary>
        /// <param name="id">El ID del usuario.</param>
        /// <returns>Una tarea que representa la operación asíncrona, con una lista de nombres de roles.</returns>
        Task<List<string>> GetRolesByUserId(int id);

        /// <summary>
        /// Obtiene un usuario por su correo electrónico de manera asíncrona.
        /// </summary>
        /// <param name="email">El correo electrónico del usuario.</param>
        /// <returns>Una tarea que representa la operación asíncrona, con un resultado de tipo <see cref="User"/> si se encuentra.</returns>
        Task<User?> GetByEmailAsync(string email);

        /// <summary>
        /// Actualiza un usuario de manera asíncrona.
        /// </summary>
        /// <param name="user">La entidad de usuario con los datos actualizados.</param>
        Task UpdateAsync(User user);

        
        Task<User?> GetByIdAsync(int id);
    }
}

