using Entity.Dtos.ModuleOperation;
using Entity.Dtos.ModuleOperational;
using Entity.Models.ModuleOperation;
using Entity.Requests.ModuleOperation;
using Service.Interfaces.IModuleBaseService;

namespace Service.Interfaces.ModelOperationService
{
    public interface IDevelopmentService : IBaseModelService<Development, DevelopmentDTO, DevelopmentRequest>
    {
    }
}
