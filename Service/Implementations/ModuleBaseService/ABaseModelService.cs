using Entity.Dtos.ModuleBase;
using Entity.Models.ModuleBase;
using Entity.Requests.ModuleBase;
using Entity.Requests.ModuleSegurity;
using Service.Interfaces.IModuleBaseService;

namespace Service.Implementations.ModuleBaseService
{
    /// <summary>
    /// Clase base abstracta que define la estructura de un servicio genérico 
    /// para manejar operaciones CRUD sobre entidades del dominio.
    /// 
    /// Esta clase debe ser heredada por servicios concretos que implementen
    /// la lógica de negocio específica de cada entidad.
    /// </summary>
    /// <typeparam name="T">El tipo de entidad, que debe heredar de <see cref="BaseModel"/>.</typeparam>
    /// <typeparam name="D">El tipo DTO asociado a la entidad, que debe heredar de <see cref="BaseDTO"/>.</typeparam>
    /// <typeparam name="R">El tipo de objeto de transferencia de datos (Request), que debe heredar de <see cref="BaseRequest"/>.</typeparam>
    public abstract class ABaseModelService<T, D, R> : IBaseModelService<T, D, R>
        where T : BaseModel
        where D : BaseDTO
        where R : BaseRequest
    {
        /// <summary>
        /// Elimina una entidad del sistema a partir de su identificador único.
        /// En implementaciones concretas, puede realizar eliminación lógica o física.
        /// </summary>
        /// <param name="id">El identificador único de la entidad a eliminar.</param>
        /// <returns>Una tarea asincrónica que representa la operación de eliminación.</returns>
        public abstract Task Delete(int id);

        /// <summary>
        /// Recupera todas las entidades aplicando filtros, paginación y ordenamiento
        /// según lo definido en <see cref="QueryFilterRequest"/>.
        /// </summary>
        /// <param name="filters">Objeto con los parámetros opcionales de filtrado, paginación y ordenamiento.</param>
        /// <returns>
        /// Una tarea asincrónica cuyo resultado es una colección de objetos de tipo <typeparamref name="R"/> 
        /// representando las entidades obtenidas.
        /// </returns>
        public abstract Task<IEnumerable<R>> GetAll(QueryFilterRequest filters);

        /// <summary>
        /// Recupera una entidad específica a partir de su identificador único.
        /// </summary>
        /// <param name="id">El identificador único de la entidad a consultar.</param>
        /// <returns>
        /// Una tarea asincrónica cuyo resultado es el objeto de tipo <typeparamref name="T"/> 
        /// correspondiente si existe, o <c>null</c> en caso contrario.
        /// </returns>
        public abstract Task<T> GetById(int id);

        /// <summary>
        /// Guarda una nueva entidad en el sistema.
        /// </summary>
        /// <param name="entity">La entidad que se desea persistir.</param>
        /// <returns>
        /// Una tarea asincrónica cuyo resultado es la entidad persistida, incluyendo valores generados automáticamente (ej. ID).
        /// </returns>
        public abstract Task<T> Save(T entity);

        /// <summary>
        /// Actualiza una entidad existente en el sistema.
        /// </summary>
        /// <param name="entity">La entidad con los valores actualizados.</param>
        /// <returns>Una tarea asincrónica que representa la operación de actualización.</returns>
        public abstract Task Update(T entity);

        /// <summary>
        /// Restaura una entidad previamente eliminada (en caso de eliminación lógica).
        /// </summary>
        /// <param name="id">El identificador único de la entidad a restaurar.</param>
        /// <returns>Una tarea asincrónica que representa la operación de restauración.</returns>
        public abstract Task Restore(int id);
    }
}

