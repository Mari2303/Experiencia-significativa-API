using Entity.Dtos.ModuleBase;
using Entity.Models.ModuleBase;
using Entity.Requests.ModuleBase;
using Entity.Requests.ModuleSegurity;
using Repository.Interfaces.IModuleBaseRepository;

namespace Repository.Implementations.ModuleBaseRepository
{
    /// <summary>
    /// Clase abstracta base de repositorio que define operaciones genéricas 
    /// para las capas de acceso a datos.
    /// </summary>
    /// <typeparam name="T">El tipo de entidad, que debe heredar de <see cref="BaseModel"/>.</typeparam>
    /// <typeparam name="D">El tipo de objeto de transferencia de datos (DTO), 
    /// que debe heredar de <see cref="BaseDTO"/>.</typeparam>
    /// <typeparam name="R">El tipo de objeto de transferencia (Request), 
    /// que debe heredar de <see cref="BaseRequest"/>.</typeparam>
    public abstract class ABaseModelRepository<T, D, R> : IBaseModelRepository<T, D, R>
        where T : BaseModel
        where D : BaseDTO
        where R : BaseRequest
    {
        /// <summary>
        /// Recupera todas las entidades como una colección de DTOs.
        /// </summary>
        /// <param name="filters">Filtros de búsqueda, ordenamiento y paginación.</param>
        /// <returns>
        /// Una tarea que representa la operación asincrónica, 
        /// que contiene una colección de <typeparamref name="R"/>.
        /// </returns>
        public abstract Task<IEnumerable<R>> GetAll(QueryFilterRequest filters);

        /// <summary>
        /// Recupera una sola entidad por su identificador único.
        /// </summary>
        /// <param name="id">El identificador único de la entidad.</param>
        /// <returns>
        /// Una tarea que representa la operación asincrónica, 
        /// que contiene la entidad de tipo <typeparamref name="T"/>.
        /// </returns>
        public abstract Task<T> GetById(int id);

        /// <summary>
        /// Guarda una nueva entidad en la base de datos.
        /// </summary>
        /// <param name="entity">La entidad de tipo <typeparamref name="T"/> a guardar.</param>
        /// <returns>
        /// Una tarea que representa la operación asincrónica, 
        /// que contiene la entidad guardada.
        /// </returns>
        public abstract Task<T> Save(T entity);

        /// <summary>
        /// Actualiza una entidad existente en la base de datos.
        /// </summary>
        /// <param name="entity">La entidad de tipo <typeparamref name="T"/> a actualizar.</param>
        /// <returns>
        /// Una tarea que representa la operación asincrónica.
        /// </returns>
        public abstract Task Update(T entity);

        /// <summary>
        /// Elimina una entidad de la base de datos en base a su identificador único.
        /// </summary>
        /// <param name="id">El ID de la entidad a eliminar.</param>
        /// <returns>
     
        public abstract Task Delete(int id);

        /// <summary>
        /// Restaura una entidad previamente eliminada (si aplica eliminación lógica).
        /// </summary>
        /// <param name="id">El ID de la entidad a restaurar.</param>
        /// <returns>
        /// Una tarea que representa la operación asincrónica.
        /// </returns>
        public abstract Task Restore(int id);
    }
}
