using Entity.Dtos.ModuleSegurity;
using Entity.Models.ModuleSegurity;
using Entity.Requests.ModuleSegurity;
using Repository.Interfaces.IModuleBaseRepository;

namespace Repository.Interfaces.IModuleSegurityRepository
{
    
    public interface IPermissionRepository : IBaseModelRepository<Permission, PermissionDTO, PermissionRequest>
    {
    }
}
