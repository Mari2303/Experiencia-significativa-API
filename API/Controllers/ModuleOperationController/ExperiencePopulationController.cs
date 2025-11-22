using API.Controllers.ModuleBaseController;
using AutoMapper;
using Entity.Dtos.ModuleOperational;
using Entity.Models.ModuleOperation;
using Entity.Requests.ModuleOperation;
using Service.Interfaces.IModuleBaseService;
using Service.Interfaces.ModelOperationService;

namespace API.Controllers.ModuleOperationController
{
    public class ExperiencePopulationController : BaseModelController<ExperiencePopulation, ExperiencePopulationDTO, ExperiencePopulationRequest>
    {
        private readonly IExperiencePopulationService _experiencePopulationService;
        private readonly IMapper _mapper;
        public ExperiencePopulationController(IBaseModelService<ExperiencePopulation, ExperiencePopulationDTO, ExperiencePopulationRequest> baseService, IExperiencePopulationService experiencePopulationService, IMapper mapper) : base(baseService, mapper)
        {
            _experiencePopulationService = experiencePopulationService;
            _mapper = mapper;
        }
    }
}
