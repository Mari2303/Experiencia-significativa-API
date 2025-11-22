using API.Controllers.ModuleBaseController;
using AutoMapper;
using Entity.Dtos.ModuleOperational;
using Entity.Models.ModuleOperation;
using Entity.Requests.ModuleOperation;
using Service.Interfaces.IModuleBaseService;
using Service.Interfaces.ModelOperationService;

namespace API.Controllers.ModuleOperationController
{
    public class ExperienceLineThematicController : BaseModelController<ExperienceLineThematic, ExperienceLineThematicDTO, ExperienceLineThematicRequest>
    {
        private readonly IExperienceLineThematicService _experienceLineThematicService;
        private readonly IMapper _mapper;
        public ExperienceLineThematicController(IBaseModelService<ExperienceLineThematic, ExperienceLineThematicDTO, ExperienceLineThematicRequest> baseService, IExperienceLineThematicService experienceLineThematicService, IMapper mapper) : base(baseService, mapper)
        {
            _experienceLineThematicService = experienceLineThematicService;
            _mapper = mapper;
        }
    }
}
