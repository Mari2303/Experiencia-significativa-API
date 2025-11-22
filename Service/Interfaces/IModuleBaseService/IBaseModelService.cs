using Entity.Dtos.ModuleBase;
using Entity.Models.ModuleBase;
using Entity.Requests.ModuleBase;
using Entity.Requests.ModuleSegurity;

namespace Service.Interfaces.IModuleBaseService
{
    /// <summary>
    /// Define el contrato para una capa de servicio genérica que realiza operaciones CRUD básicas
    /// sobre entidades y sus correspondientes Objetos de Transferencia de Datos (DTOs).
    /// </summary>
    /// <typeparam name="T">El tipo de entidad, que debe heredar de <see cref="BaseModel"/>.</typeparam>
    /// <typeparam name="D">El tipo de DTO, que debe heredar de <see cref="BaseDTO"/>.</typeparam>
    /// <typeparam name="R">El tipo de solicitud, que debe heredar de <see cref="BaseRequest"/>.</typeparam>
    public interface IBaseModelService<T, D, R>
        where T : BaseModel
        where D : BaseDTO
        where R : BaseRequest
    {
        /// <summary>
        /// Recupera todos los registros del tipo de entidad y los mapea a DTOs.
        /// </summary>
        /// <param name="filters">Filtros opcionales para refinar la consulta.</param>
        /// <returns>Una tarea que representa la operación asincrónica, conteniendo una colección de DTOs.</returns>
        Task<IEnumerable<R>> GetAll(QueryFilterRequest filters);

        /// <summary>
        /// Recupera una entidad específica por su identificador único.
        /// </summary>
        /// <param name="id">El ID de la entidad a recuperar.</param>
        /// <returns>Una tarea que representa la operación asincrónica, conteniendo la entidad si es encontrada.</returns>
        Task<T> GetById(int id);

        /// <summary>
        /// Persiste una nueva entidad en la base de datos subyacente.
        /// </summary>
        /// <param name="entity">La entidad a guardar.</param>
        /// <returns>Una tarea que representa la operación asincrónica, conteniendo la entidad guardada.</returns>
        Task<T> Save(T entity);

        /// <summary>
        /// Actualiza una entidad existente en la base de datos.
        /// </summary>
        /// <param name="entity">La entidad con los valores actualizados.</param>
        /// <returns>Una tarea que representa la operación asincrónica.</returns>
        Task Update(T entity);

        /// <summary>
        /// Elimina una entidad basada en su identificador único.
        /// </summary>
        /// <param name="id">El ID de la entidad a eliminar.</param>
        /// <returns>Una tarea que representa la operación asincrónica.</returns>
        Task Delete(int id);

        /// <summary>
        /// Restaura una entidad previamente eliminada de manera lógica.
        /// </summary>
        /// <param name="id">El ID de la entidad a restaurar.</param>
        /// <returns>Una tarea que representa la operación asincrónica.</returns>
        Task Restore(int id);
    }
}
