using Entity.Dtos.ModuleSegurity;
using Entity.Models.ModuleSegurity;
using Entity.Requests.ModuleSegurity;
using Repository.Interfaces.IModuleBaseRepository;

namespace Repository.Interfaces
{
    
    public interface IUserRoleRepository : IBaseModelRepository<UserRole, UserRoleDTO, UserRoleRequest>
    {
    }
}
