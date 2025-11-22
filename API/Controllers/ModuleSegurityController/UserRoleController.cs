using API.Controllers.ModuleBaseController;
using AutoMapper;
using Entity.Dtos.ModuleSegurity;
using Entity.Models.ModuleSegurity;
using Entity.Requests.ModuleSegurity;
using Service.Interfaces.IModuleBaseService;
using Service.Interfaces.IModuleSegurityService;

namespace API.Controllers.ModuleSegurityController
{
    public class UserRoleController : BaseModelController<UserRole, UserRoleDTO, UserRoleRequest>
    {
        private readonly IUserRoleService _userRolService;
        private readonly IMapper _mapper;

        public UserRoleController(IBaseModelService<UserRole, UserRoleDTO, UserRoleRequest> baseService, IUserRoleService service, IMapper mapper) : base(baseService, mapper)
        {
            _userRolService = service;
            _mapper = mapper;
        }
    }
}
