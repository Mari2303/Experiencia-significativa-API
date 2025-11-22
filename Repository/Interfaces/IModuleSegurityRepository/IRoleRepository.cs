using Entity.Dtos;
using Entity.Models.ModuleSegurity;
using Entity.Requests.ModuleSegurity;
using Repository.Interfaces.IModuleBaseRepository;

namespace Repository.Interfaces.IModuleSegurityRepository
{

    public interface IRoleRepository : IBaseModelRepository<Role, RoleDTO, RoleRequest>
    {
        Task<Role> GetByNameRol(string roleName);

    }
}
