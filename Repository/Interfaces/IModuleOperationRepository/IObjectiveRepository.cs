using Entity.Dtos.ModuleOperational;
using Entity.Models.ModuleOperation;
using Entity.Requests.ModuleOperation;
using Repository.Interfaces.IModuleBaseRepository;

namespace Repository.Interfaces.IModuleOperationRepository
{
    public interface IObjectiveRepository : IBaseModelRepository<Objective, ObjectiveDTO, ObjectiveRequest>
    {
    }
}
