using Service.Interfaces.IModuleBaseService;
using Entity.Dtos.ModuleSegurity;
using Entity.Models.ModuleSegurity;
using Entity.Requests.ModuleSegurity;

namespace Service.Interfaces.IModuleSegurityService
{
    
    public interface IPermissionService : IBaseModelService<Permission, PermissionDTO, PermissionRequest>
    {
    }
}
