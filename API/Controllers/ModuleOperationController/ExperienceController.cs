using System.Security.Claims;
using API.Controllers.ModuleBaseController;
using AutoMapper;
using Entity.Dtos.ModuleOperational;
using Entity.Models.ModuleOperation;
using Entity.Requests.EntityData.EntityCreateRequest;
using Entity.Requests.EntityData.EntityUpdateRequest;
using Entity.Requests.ModuleOperation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces.IModuleBaseService;
using Service.Interfaces.ModelOperationService;

namespace API.Controllers.ModuleOperationController
{
    public class ExperienceController : BaseModelController<Experience, ExperienceDTO, ExperienceRequest>
    {
        private readonly IExperienceService _experienceService;
        private readonly IMapper _mapper;
        public ExperienceController(IBaseModelService<Experience, ExperienceDTO, ExperienceRequest> baseService, IExperienceService experienceService, IMapper mapper) : base(baseService, mapper)
        {
            _experienceService = experienceService;
            _mapper = mapper;
        }


        [Authorize]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] ExperienceCreateRequest request)
        {
            if (request == null)
                return BadRequest("El DTO no puede estar vacío.");

            try
            {
                var experience = await _experienceService.RegisterExperienceAsync(request);
                return Ok(experience);
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, $"Ocurrió un error al registrar la experiencia: {ex.Message}");
            }

        }

        [Authorize]
        [HttpGet("{id}/generate-pdf")]
        public async Task<IActionResult> GeneratePdf(int id)
        {
            var url = await _experienceService.GeneratePdfAndUploadAsync(id);

            return Ok(new
            {
                Message = "PDF generado correctamente",
                PdfUrl = url
            });
        }




        [Authorize]
        [HttpGet("{id}/detail")]
        public async Task<IActionResult> Detail(int id)
        {
            var dto = await _experienceService.GetDetailByIdAsync(id);
            if (dto == null) return NotFound();

            return Ok(dto); // devuelve JSON
        }




        [Authorize]
        [HttpPatch("patch")]
        public async Task<IActionResult> Patch([FromBody] ExperienceUpdateRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var success = await _experienceService.PatchAsync(request);
            if (!success) return NotFound();

            return Ok(new { message = "Experience patched successfully" });
        }



        [Authorize]
        [HttpGet("List")]
        public async Task<IActionResult> GetExperiences()
        {
            var userId = int.Parse(User.Claims.First(c => c.Type == "id").Value);
            var role = User.Claims.First(c => c.Type == ClaimTypes.Role).Value;

            var experiences = await _experienceService.GetExperiencesAsync(role, userId);
            return Ok(experiences);
        }






       
        [HttpPost("{id}/request-edit")]
        public async Task<IActionResult> RequestEdit(int id,  int userId)
        {
            await _experienceService.RequestEditAsync(id, userId);
            return Ok(new { message = "Solicitud enviada. Espera aprobación." });
        }


        [Authorize(Roles = "SUPERADMIN")]
        [HttpPost("{id}/approve-edit")]
        public async Task<IActionResult> ApproveEdit(int id)
        {
            await _experienceService.ApproveEditAsync(id);
            return Ok(new { message = "Edición habilitada." });
        }

        [Authorize(Roles = "SUPERADMIN")]
        [HttpGet("all/Notification")]
        public async Task<IActionResult> GetAllPermissions()
        {
            var list = await _experienceService.GetAllAsync();
            return Ok(list);  
        }


        [Authorize(Roles = "SUPERADMIN")]
        [HttpGet("detail/Form/{id}")]
        public async Task<IActionResult> GetDetail(int id)
        {
            var experience = await _experienceService.GetDetailAsync(id);

            if (experience == null)
                return NotFound("No se encontró la experiencia.");

            return Ok(experience);
        }



    }
}


    

