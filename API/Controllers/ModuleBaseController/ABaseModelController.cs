using Entity.Dtos.ModuleBase;
using Entity.Models.ModuleBase;
using Entity.Requests.ModuleBase;
using Entity.Requests.ModuleSegurity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.ModuleBaseController
{
    /// <summary>
    /// Controlador base abstracto que define endpoints REST genéricos para manejar entidades.
    /// Este controlador se utiliza como plantilla para otros controladores específicos de entidades concretas.
    /// </summary>
    /// <typeparam name="T">Tipo de entidad, debe heredar de <see cref="BaseModel"/>.</typeparam>
    /// <typeparam name="D">Tipo de DTO (Data Transfer Object), debe heredar de <see cref="BaseDTO"/>.</typeparam>
    /// <typeparam name="R">Tipo de Request, debe heredar de <see cref="BaseRequest"/>.</typeparam>
    public abstract class ABaseModelController<T, D, R> : ControllerBase
        where T : BaseModel
        where D : BaseDTO
        where R : BaseRequest
    {
        /// <summary>
        /// Obtiene todas las entidades aplicando filtros opcionales.
        /// </summary>
        /// <param name="filters">Filtros opcionales para la consulta.</param>
        /// <returns>Una lista de entidades convertidas a DTOs (tipo <typeparamref name="R"/>).</returns>
        public abstract Task<ActionResult<IEnumerable<R>>> GetAll(QueryFilterRequest filters);

        /// <summary>
        /// Obtiene una entidad específica por su ID.
        /// </summary>
        /// <param name="id">El identificador único de la entidad.</param>
        /// <returns>La entidad convertida a DTO (tipo <typeparamref name="D"/>).</returns>
        public abstract Task<ActionResult<D>> GetById(int id);

        /// <summary>
        /// Crea una nueva entidad a partir de un DTO.
        /// </summary>
        /// <param name="request">DTO con los datos de la entidad a crear.</param>
        /// <returns>La entidad creada como DTO.</returns>
        public abstract Task<ActionResult<D>> Save(D request);

        /// <summary>
        /// Actualiza una entidad existente a partir de un DTO.
        /// </summary>
        /// <param name="request">DTO con los datos actualizados de la entidad.</param>
        /// <returns>Resultado de la operación de actualización.</returns>
        public abstract Task<ActionResult<D>> Update(D request);

        /// <summary>
        /// Elimina una entidad según su ID.
        /// </summary>
        /// <param name="id">El ID de la entidad a eliminar.</param>
        /// <returns>Resultado de la operación de eliminación.</returns>
        public abstract Task<ActionResult> Delete(int id);

        /// <summary>
        /// Restaura una entidad previamente eliminada (soft delete).
        /// </summary>
        /// <param name="id">El ID de la entidad a restaurar.</param>
        /// <returns>Resultado de la operación de restauración.</returns>
        public abstract Task<ActionResult> Restore(int id);
    }
}
