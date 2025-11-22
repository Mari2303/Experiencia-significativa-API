using Entity.Dtos.ModuleSegurity;
using Entity.Models.ModuleSegurity;
using Entity.Requests.ModuleSegurity;
using Repository.Interfaces.IModuleSegurityRepository;
using Service.Implementations.ModuleBaseService;
using Service.Interfaces.IModuleSegurityService;

namespace Service.Implementations.ModuleSegurityService
{
    
    public class RoleFormPermissionService : BaseModelService<RoleFormPermission, RoleFormPermissionDTO, RoleFormPermissionRequest>, IRoleFormPermissionService
    {
        private readonly IRoleFormPermissionRepository _roleFormPermissionRepository;

      
        public RoleFormPermissionService(IRoleFormPermissionRepository roleFormPermissionRepository) : base(roleFormPermissionRepository)
        {
            _roleFormPermissionRepository = roleFormPermissionRepository;
        }
    }
}
