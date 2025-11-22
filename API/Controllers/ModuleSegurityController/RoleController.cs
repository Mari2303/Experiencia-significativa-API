using API.Controllers.ModuleBaseController;
using AutoMapper;
using Entity.Dtos;
using Entity.Models.ModuleSegurity;
using Entity.Requests.ModuleSegurity;
using Service.Interfaces.IModuleBaseService;
using Service.Interfaces.IModuleSegurityService;

namespace API.Controllers.ModuleSegurityController
{
    public class RoleController : BaseModelController<Role, RoleDTO, RoleRequest>
    {
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;

        public RoleController(IBaseModelService<Role, RoleDTO, RoleRequest> baseService, IRoleService service, IMapper mapper) : base(baseService, mapper)
        {
            _roleService = service;
            _mapper = mapper;
        }
    }
}
