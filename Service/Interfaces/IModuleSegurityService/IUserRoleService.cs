using Entity.Dtos.ModuleSegurity;
using Entity.Models.ModuleSegurity;
using Entity.Requests.ModuleSegurity;
using Service.Interfaces.IModuleBaseService;

namespace Service.Interfaces.IModuleSegurityService
{
    
    public interface IUserRoleService : IBaseModelService<UserRole, UserRoleDTO, UserRoleRequest>
    {
    }
}
