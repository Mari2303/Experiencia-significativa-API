using Entity.Dtos.ModuleSegurity;
using Entity.Models.ModuleSegurity;
using Entity.Requests.ModuleSegurity;
using Repository.Interfaces.IModuleSegurityRepository;
using Service.Implementations.ModuleBaseService;
using Service.Interfaces.IModuleSegurityService;

namespace Service.Implementations.ModuleSegurityService
{
   
    public class PermissionService : BaseModelService<Permission, PermissionDTO, PermissionRequest>, IPermissionService
    {
        private readonly IPermissionRepository _permissionRepository;

    
        public PermissionService(IPermissionRepository permissionRepository) : base(permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }
    }
}
