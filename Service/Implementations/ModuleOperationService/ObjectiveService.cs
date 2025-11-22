using Entity.Dtos.ModuleOperational;
using Entity.Models.ModuleOperation;
using Entity.Requests.ModuleOperation;
using Repository.Interfaces.IModuleOperationRepository;
using Service.Implementations.ModuleBaseService;
using Service.Interfaces.ModelOperationService;

namespace Service.Implementations.ModelOperationService
{
    public class ObjectiveService : BaseModelService<Objective, ObjectiveDTO, ObjectiveRequest>, IObjectiveService
    {
        private readonly IObjectiveRepository _objectiveRepository;
        public ObjectiveService(IObjectiveRepository objectiveRepository) : base(objectiveRepository)
        {
            _objectiveRepository = objectiveRepository;
        }
    }
}
