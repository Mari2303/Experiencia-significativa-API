using AutoMapper;
using Entity.Context;
using Entity.Dtos.ModuleSegurity;
using Entity.Models.ModuleSegurity;
using Entity.Requests.ModuleSegurity;
using Microsoft.Extensions.Configuration;
using Repository.Implementations.ModuleBaseRepository;
using Repository.Interfaces.IModuleSegurityRepository;
using Utilities.Helper;

namespace Repository.Implementations.ModuleSegurityRepository
{
   
    public class PermissionRepository : BaseModelRepository<Permission, PermissionDTO, PermissionRequest>, IPermissionRepository
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IHelper<Permission, PermissionDTO> _helperRepository;

        public PermissionRepository(ApplicationContext context, IMapper mapper, IConfiguration configuration, IHelper<Permission, PermissionDTO> helperRepository) : base(context, mapper, configuration, helperRepository)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
            _helperRepository = helperRepository;
        }
    }
}
