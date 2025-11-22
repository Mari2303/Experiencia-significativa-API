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
    /// Controlador para operaciones auxiliares o de apoyo, como obtener los valores de un enum.
    /// Hereda de <see cref="AHelperController"/> que define la estructura base de estos métodos.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class HelperController : AHelperController
    {
        private readonly IHelperService<BaseModel, BaseDTO> _helperService; // Servicio auxiliar genérico
        private readonly IMapper _mapper; // Mapper para convertir entre modelos y DTOs (aunque aquí no se usa directamente)

        /// <summary>
        /// Constructor del controlador HelperController.
        /// </summary>
        /// <param name="helperService">Servicio auxiliar inyectado.</param>
        /// <param name="mapper">Instancia de AutoMapper.</param>
        public HelperController(IHelperService<BaseModel, BaseDTO> helperService, IMapper mapper)
        {
            _helperService = helperService;
            _mapper = mapper;
        }

        /// <summary>
        /// Obtiene los valores de un Enum como lista de objetos <see cref="DataSelectRequest"/>.
        /// Esto permite enviar al frontend un listado que se puede usar en select, dropdowns o filtros.
        /// </summary>
        /// <param name="enumName">Nombre del enum del cual se quieren los valores.</param>
        /// <returns>Lista de valores del enum en formato de <see cref="DataSelectRequest"/>.</returns>
        [AllowAnonymous] // Puede ser accedido sin autenticación
        [HttpGet("{enumName}")]
        public override async Task<ActionResult<IEnumerable<DataSelectRequest>>> GetEnum(string enumName)
        {
            try
            {
                // Llama al servicio helper para obtener los valores del enum
                var data = await _helperService.GetEnum(enumName);

                if (data == null)
                {
                    // Si no se encuentra el enum, devuelve NotFound
                    var responseNull = new ApiResponseRequest<IEnumerable<DataSelectRequest>>(null!, false, "Records not found");
                    return NotFound(responseNull);
                }

                // Devuelve los datos con éxito
                var response = new ApiResponseRequest<IEnumerable<DataSelectRequest>>(data, true, "Ok");
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Manejo de errores generales
                var response = new ApiResponseRequest<IEnumerable<DataSelectRequest>>(null!, false, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }
    }
}
