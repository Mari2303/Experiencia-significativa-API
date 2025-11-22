using Entity.Dtos;
using Entity.Models.ModuleSegurity;
using Entity.Requests.ModuleSegurity;
using Service.Interfaces.IModuleBaseService;

namespace Service.Interfaces.IModuleSegurityService
{
  
    public interface IRoleService : IBaseModelService<Role, RoleDTO, RoleRequest>
    {
    }
}
