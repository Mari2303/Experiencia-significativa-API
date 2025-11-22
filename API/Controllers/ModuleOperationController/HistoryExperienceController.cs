using System.Security.Claims;
using API.Controllers.ModuleBaseController;
using AutoMapper;
using Entity.Dtos.ModuleOperational;
using Entity.Models.ModuleOperation;
using Entity.Requests.ModuleOperation;
using Entity.Requests.ModuleSegurity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces.IModuleBaseService;
using Service.Interfaces.ModelOperationService;

namespace API.Controllers.ModuleOperationController
{
    public class HistoryExperienceController : BaseModelController<HistoryExperience, HistoryExperienceDTO, HistoryExperienceRequest>
    {
        private readonly IHistoryExperienceService _historyExperienceService;
        private readonly IMapper _mapper;
        public HistoryExperienceController(IBaseModelService<HistoryExperience, HistoryExperienceDTO, HistoryExperienceRequest> baseService, IHistoryExperienceService historyExperienceService, IMapper mapper) : base(baseService, mapper)
        {
            _historyExperienceService = historyExperienceService;
            _mapper = mapper;
        }

        [Authorize]
        [HttpPost("tracking-summary")]
        public async Task<IActionResult> GetTrackingSummary([FromBody] QueryFilterRequest filters)
        {
            var role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            var userId = int.Parse(User.Claims.First(c => c.Type == "id").Value);

            filters.Role = role;   // Se asigna desde el JWT
            filters.UserId = userId; // Igual con el Id

            var result = await _historyExperienceService.GetTrackingSummaryAsync(filters);
            return Ok(result);
        }



    }
}
