
using Entity.Dtos.ModuleOperational;
using Entity.Models.ModuleOperation;
using Entity.Requests.ModuleOperation;
using Service.Interfaces.IModuleBaseService;

namespace Service.Interfaces.ModelOperationService
{
    public interface IObjectiveService : IBaseModelService<Objective, ObjectiveDTO, ObjectiveRequest>
    {
    }
}
