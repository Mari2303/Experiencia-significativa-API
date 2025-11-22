using Entity.Dtos.ModuleOperation;
using Entity.Models.ModuleOperation;
using Entity.Requests.ModuleOperation;
using Repository.Interfaces.IModuleOperationRepository;
using Service.Implementations.ModuleBaseService;
using Service.Interfaces.ModelOperationService;

namespace Service.Implementations.ModelOperationService
{
    public class LeaderService : BaseModelService<Leader, LeaderDTO, LeaderRequest>, ILeaderService
    {
        private readonly ILeaderRepository _leaderRepository;
        public LeaderService(ILeaderRepository leaderRepository) : base(leaderRepository)
        {
            _leaderRepository = leaderRepository;
        }
    }
}
