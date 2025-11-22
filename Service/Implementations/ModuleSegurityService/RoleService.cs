using Entity.Dtos;
using Entity.Models.ModuleSegurity;
using Entity.Requests.ModuleSegurity;
using Repository.Interfaces.IModuleSegurityRepository;
using Service.Implementations.ModuleBaseService;
using Service.Interfaces.IModuleSegurityService;

namespace Service.Implementations.ModuleSegurityService
{
   
    public class RoleService : BaseModelService<Role, RoleDTO, RoleRequest>, IRoleService
    {
        private readonly IRoleRepository _roleRepository;

       
        public RoleService(IRoleRepository roleRepository) : base(roleRepository)
        {
            _roleRepository = roleRepository;
        }
    }
}
