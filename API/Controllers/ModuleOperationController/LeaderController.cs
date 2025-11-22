using API.Controllers.ModuleBaseController;
using AutoMapper;
using Entity.Dtos.ModuleOperation;
using Entity.Models.ModuleOperation;
using Entity.Requests.ModuleOperation;
using Service.Interfaces.IModuleBaseService;
using Service.Interfaces.ModelOperationService;

namespace API.Controllers.ModuleOperationController
{
    public class LeaderController : BaseModelController<Leader, LeaderDTO, LeaderRequest>
    {
        private readonly ILeaderService _leaderService;
        private readonly IMapper _mapper;

        public LeaderController(IBaseModelService<Leader, LeaderDTO, LeaderRequest> baseService, ILeaderService leaderService, IMapper mapper) : base(baseService, mapper)
        {
            _leaderService = leaderService;
            _mapper = mapper;
        }
    }
}
