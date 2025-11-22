using API.Controllers.ModuleBaseController;
using AutoMapper;
using Entity.Dtos.ModuleOperational;
using Entity.Models.ModuleOperation;
using Entity.Requests.ModuleOperation;
using Service.Interfaces.IModuleBaseService;
using Service.Interfaces.ModelOperationService;

namespace API.Controllers.ModuleOperationController
{
    public class ObjectiveController : BaseModelController<Objective, ObjectiveDTO, ObjectiveRequest>
    {
        private readonly IObjectiveService _objectiveService;
        private readonly IMapper _mapper;
        public ObjectiveController(IBaseModelService<Objective, ObjectiveDTO, ObjectiveRequest> baseService, IObjectiveService objectiveService, IMapper mapper) : base(baseService, mapper)
        {
            _objectiveService = objectiveService;
            _mapper = mapper;
        }
    }
}
