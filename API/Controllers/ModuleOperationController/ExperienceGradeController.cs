using API.Controllers.ModuleBaseController;
using AutoMapper;
using Entity.Dtos.ModuleOperational;
using Entity.Models.ModuleOperation;
using Entity.Requests.ModuleOperation;
using Service.Interfaces.IModuleBaseService;
using Service.Interfaces.ModelOperationService;

namespace API.Controllers.ModuleOperationController
{
    public class ExperienceGradeController : BaseModelController<ExperienceGrade, ExperienceGradeDTO, ExperienceGradeRequest>
    {
        private readonly IExperienceGradeService _experienceGradeService;
        private readonly IMapper _mapper;
        public ExperienceGradeController(IBaseModelService<ExperienceGrade, ExperienceGradeDTO, ExperienceGradeRequest> baseService, IExperienceGradeService experienceGradeService, IMapper mapper) : base(baseService, mapper)
        {
            _experienceGradeService = experienceGradeService;
            _mapper = mapper;
        }
    }
}
