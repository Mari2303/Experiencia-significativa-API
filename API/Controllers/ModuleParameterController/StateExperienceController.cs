using AutoMapper;
using Entity.Dtos.ModelosParametro;
using Entity.Models.ModelosParametros;
using Entity.Requests.ModulesParamer;
using Service.Interfaces.ModuleParamer;
using Service.Interfaces.IModuleBaseService;
using API.Controllers.ModuleBaseController;

namespace API.Controllers.ModuleParamer
{
    public class StateExperienceController : BaseModelController<StateExperience, StateExperienceDTO, StateExperienceRequest>
    {
        private readonly IStateExperienceService _stateService;
        private readonly IMapper _mapper;

        public StateExperienceController(IBaseModelService<StateExperience, StateExperienceDTO, StateExperienceRequest> baseService, IStateExperienceService service, IMapper mapper) : base(baseService, mapper)
        {
            _stateService = service;
            _mapper = mapper;
        }
    }
}
