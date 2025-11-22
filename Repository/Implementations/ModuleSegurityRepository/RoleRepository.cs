using AutoMapper;
using Entity.Context;
using Entity.Dtos;
using Entity.Models.ModuleSegurity;
using Entity.Requests.ModuleSegurity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repository.Implementations.ModuleBaseRepository;
using Repository.Interfaces.IModuleSegurityRepository;
using Utilities.Helper;

namespace Repository.Implementations.ModuleSegurityRepository
{
  
    public class RoleRepository : BaseModelRepository<Role, RoleDTO, RoleRequest>,IRoleRepository
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IHelper<Role, RoleDTO> _helperRepository;

        public RoleRepository(ApplicationContext context, IMapper mapper, IConfiguration configuration, IHelper<Role, RoleDTO> helperRepository) : base(context, mapper, configuration, helperRepository)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
            _helperRepository = helperRepository;
        }

        public async Task<Role> GetByNameRol(string roleName)
        {
            return await _context.Roles.FirstOrDefaultAsync(r => r.Name == roleName);
        }







    }
}
