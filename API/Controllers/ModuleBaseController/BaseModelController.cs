using AutoMapper;
using Entity.Dtos.ModuleBase;
using Entity.Models.ModuleBase;
using Entity.Requests.ModuleBase;
using Entity.Requests.ModuleSegurity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces.IModuleBaseService;

namespace API.Controllers.ModuleBaseController
{
    /// <summary>
    /// Controlador genérico que maneja operaciones CRUD básicas para cualquier entidad del sistema.
    /// Se basa en un servicio genérico <see cref="IBaseModelService{T,D,R}"/> y utiliza AutoMapper para convertir entre
    /// entidades y DTOs.
    /// </summary>
    /// <typeparam name="T">Tipo de entidad, que debe heredar de <see cref="BaseModel"/>.</typeparam>
    /// <typeparam name="D">Tipo de DTO, que debe heredar de <see cref="BaseDTO"/>.</typeparam>
    /// <typeparam name="R">Tipo de Request, que debe heredar de <see cref="BaseRequest"/>.</typeparam>
    [ApiController]
    [Route("api/[controller]")]
    public class BaseModelController<T, D, R> : ABaseModelController<T, D, R>
        where T : BaseModel
        where D : BaseDTO
        where R : BaseRequest
    {
        private readonly IBaseModelService<T, D, R> _service; // Servicio de negocio genérico
        private readonly IMapper _mapper; // Mapper para convertir entre entidad y DTO

        /// <summary>
        /// Constructor del controlador genérico.
        /// </summary>
        /// <param name="service">Instancia del servicio genérico de la entidad.</param>
        /// <param name="mapper">Instancia de AutoMapper.</param>
        public BaseModelController(IBaseModelService<T, D, R> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        /// <summary>
        /// Obtiene todos los registros de la entidad filtrados opcionalmente por <see cref="QueryFilterRequest"/>.
        /// </summary>
        /// <param name="filters">Filtros opcionales de consulta.</param>
        /// <returns>Lista de DTOs de la entidad.</returns>
        [Authorize] // Requiere autenticación
        [HttpGet("getAll")]
        public override async Task<ActionResult<IEnumerable<R>>> GetAll([FromQuery] QueryFilterRequest filters)
        {
            try
            {
                var data = await _service.GetAll(filters);
                if (data == null)
                    return NotFound(new ApiResponseRequest<IEnumerable<R>>(null!, false, "Records not found"));

                return Ok(new ApiResponseRequest<IEnumerable<R>>(data, true, "Ok"));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new ApiResponseRequest<IEnumerable<R>>(null!, false, ex.Message));
            }
        }

        /// <summary>
        /// Obtiene un registro por su ID.
        /// </summary>
        /// <param name="id">ID de la entidad.</param>
        /// <returns>DTO del registro.</returns>
        [Authorize]
        [HttpGet("{id}")]
        public override async Task<ActionResult<D>> GetById(int id)
        {
            try
            {
                T data = await _service.GetById(id);
                if (data == null)
                    return NotFound(new ApiResponseRequest<D>(null!, false, "Record not found"));

                return Ok(new ApiResponseRequest<D>(_mapper.Map<D>(data), true, "Ok"));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new ApiResponseRequest<IEnumerable<D>>(null!, false, ex.Message));
            }
        }

        /// <summary>
        /// Crea un nuevo registro usando el DTO proporcionado.
        /// </summary>
        /// <param name="request">DTO del registro a crear.</param>
        /// <returns>Registro creado con mensaje de éxito.</returns>
        /// <summary>
        /// Stores a new record based on the provided DTO.
        /// </summary>
        /// <param name="dto">The DTO representing the new record.</param>
        /// <returns>An <see cref="ActionResult"/> with the stored record or an error message.</returns>
        /// [Authorize] Asegura que el acceso a este método esté restringido a los usuarios que estén autenticados y tengan los permisos adecuados
        [Authorize]
        [HttpPost]
        public override async Task<ActionResult<D>> Save(D request)
        {
            try
            {
                T saved = await _service.Save(_mapper.Map<T>(request));

                var response = new ApiResponseRequest<D>(request, true, "Record stored successfully");

                return new CreatedAtRouteResult(new { id = saved.Id }, response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponseRequest<IEnumerable<D>>(null!, false, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        /// <summary>
        /// Actualiza un registro existente con los datos del DTO proporcionado.
        /// </summary>
        /// <param name="request">DTO con los datos actualizados.</param>
        /// <returns>Registro actualizado con mensaje de éxito.</returns>
        [Authorize]
        [HttpPut]
        public override async Task<ActionResult<D>> Update(D request)
        {
            try
            {
                await _service.Update(_mapper.Map<T>(request));
                return Ok(new ApiResponseRequest<D>(request, true, "Record updated successfully"));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new ApiResponseRequest<IEnumerable<D>>(null!, false, ex.Message));
            }
        }

        /// <summary>
        /// Elimina un registro por su ID.
        /// </summary>
        /// <param name="id">ID del registro a eliminar.</param>
        /// <returns>Resultado de la operación.</returns>
        [Authorize]
        [HttpDelete("{id}")]
        public override async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _service.Delete(id);

                var successResponse = new ApiResponseRequest<D>(null!, true, "Record successfully deleted");
                return Ok(successResponse);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponseRequest<D>(null!, false, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }

        /// <summary>
        /// Restaura un registro previamente eliminado de forma lógica.
        /// </summary>
        /// <param name="id">ID del registro a restaurar.</param>
        /// <returns>Mensaje de éxito y datos del registro restaurado.</returns>
        [Authorize]
        [HttpPatch("restore/{id}")]
        public override async Task<ActionResult> Restore(int id)
        {
            await _service.Restore(id);
            var restoredEntity = await _service.GetById(id);

            return Ok(new
            {
                message = "Entity restored successfully",
                data = restoredEntity
            });
        }
    }
}
