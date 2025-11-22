using Entity.Dtos.ModuleSegurity;
using Entity.Models.ModuleSegurity;
using Entity.Requests.ModuleSegurity;
using Repository.Interfaces;
using Service.Implementations.ModuleBaseService;
using Service.Interfaces.IModuleSegurityService;

namespace Service.Implementations.ModuleSegurityService
{
   
    public class UserRoleService : BaseModelService<UserRole, UserRoleDTO, UserRoleRequest>, IUserRoleService
    {
        private readonly IUserRoleRepository _userRolRepository;

     
        public UserRoleService(IUserRoleRepository userRolRepository) : base(userRolRepository)
        {
            _userRolRepository = userRolRepository;
        }
    }
}
