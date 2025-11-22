using API.Controllers.ModuleBaseController;
using AutoMapper;
using Entity.Dtos.ModuleSegurity;
using Entity.Models.ModuleSegurity;
using Entity.Requests.ModuleSegurity;
using Service.Interfaces.IModuleBaseService;
using Service.Interfaces.IModuleSegurityService;

namespace API.Controllers.ModuleSegurityController
{
    public class PermissionController : BaseModelController<Permission, PermissionDTO, PermissionRequest>
    {
        private readonly IPermissionService _permissionService;
        private readonly IMapper _mapper;

        public PermissionController(IBaseModelService<Permission, PermissionDTO, PermissionRequest> baseService, IPermissionService service, IMapper mapper) : base(baseService, mapper)
        {
            _permissionService = service;
            _mapper = mapper;
        }
    }
}
