using Entity.Dtos.ModuleBase;
using Entity.Models.ModuleBase;
using Entity.Requests.ModuleBase;
using Entity.Requests.ModuleSegurity;

namespace Repository.Interfaces.IModuleBaseRepository
{
    /// <summary>
    /// Interfaz para operaciones relacionadas con entidades base.
    /// Esta interfaz define métodos para obtener, agregar, actualizar y eliminar entidades base en el repositorio.
    /// </summary>
    /// <typeparam name="T">Tipo de entidad que hereda de <see cref="BaseModel"/>.</typeparam>
    /// <typeparam name="D">Tipo de DTO que hereda de <see cref="BaseDTO"/>.</typeparam>
    /// <typeparam name="R">Tipo de Request que hereda de <see cref="BaseRequest"/>.</typeparam>
    public interface IBaseModelRepository<T, D, R>
        where T : BaseModel
        where D : BaseDTO
        where R : BaseRequest
    {
        /// <summary>
        /// Obtiene todas las entidades base con filtros opcionales.
        /// </summary>
        /// <param name="filters">Filtros de consulta.</param>
        /// <returns>Una tarea que representa la operación asíncrona, con una colección de resultados de tipo <see cref="R"/>.</returns>
        Task<IEnumerable<R>> GetAll(QueryFilterRequest filters);

        /// <summary>
        /// Obtiene una entidad por su ID.
        /// </summary>
        /// <param name="id">El ID de la entidad.</param>
        /// <returns>Una tarea que representa la operación asíncrona, con un resultado de tipo <see cref="T"/>.</returns>
        Task<T> GetById(int id);

        /// <summary>
        /// Agrega una nueva entidad al repositorio.
        /// </summary>
        /// <param name="entity">La entidad a agregar.</param>
        /// <returns>Una tarea que representa la operación asíncrona, con un resultado de tipo <see cref="T"/>.</returns>
        Task<T> Save(T entity);

        /// <summary>
        /// Actualiza una entidad existente en el repositorio.
        /// </summary>
        /// <param name="entity">La entidad con los datos actualizados.</param>
        /// <returns>Una tarea que representa la operación asíncrona.</returns>
        Task Update(T entity);

        /// <summary>
        /// Elimina una entidad en función de su identificador único.
        /// </summary>
        /// <param name="id">El ID de la entidad a eliminar.</param>
        /// <returns>Una tarea que representa la operación asíncrona.</returns>
        Task Delete(int id);

        /// <summary>
        /// Restaura una entidad previamente eliminada.
        /// </summary>
        /// <param name="id">El ID de la entidad a restaurar.</param>
        /// <returns>Una tarea que representa la operación asíncrona.</returns>
        Task Restore(int id);
    }
}
