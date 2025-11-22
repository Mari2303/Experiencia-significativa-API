using API.Controllers.ModuleBaseController;
using AutoMapper;
using Entity.Dtos.ModuleSegurity;
using Entity.Models.ModuleSegurity;
using Entity.Requests.ModuleSegurity;
using Service.Interfaces.IModuleBaseService;
using Service.Interfaces.IModuleSegurityService;

namespace API.Controllers.ModuleSegurityController
{
    public class RoleFormPermissionController : BaseModelController<RoleFormPermission, RoleFormPermissionDTO, RoleFormPermissionRequest>
    {
        private readonly IRoleFormPermissionService _roleFormPermissionService;
        private readonly IMapper _mapper;

        public RoleFormPermissionController(IBaseModelService<RoleFormPermission, RoleFormPermissionDTO, RoleFormPermissionRequest> baseService, IRoleFormPermissionService service, IMapper mapper) : base(baseService, mapper)
        {
            _roleFormPermissionService = service;
            _mapper = mapper;
        }
    }
}
