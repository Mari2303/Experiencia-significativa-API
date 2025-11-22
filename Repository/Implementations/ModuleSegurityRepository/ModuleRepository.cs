using AutoMapper;
using Entity.Context;
using Entity.Dtos;
using Entity.Models.ModuleSegurity;
using Entity.Requests.ModuleSegurity;
using Microsoft.Extensions.Configuration;
using Repository.Implementations.ModuleBaseRepository;
using Repository.Interfaces.IModuleSegurityRepository;
using Utilities.Helper;

namespace Repository.Implementations
{
  
    public class ModuleRepository : BaseModelRepository<Module, ModuleDTO, ModuleRequest>, IBaseModuleRepository
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IHelper<Module, ModuleDTO> _helperRepository;

        public ModuleRepository(ApplicationContext context, IMapper mapper, IConfiguration configuration, IHelper<Module, ModuleDTO> helperRepository) : base(context, mapper, configuration, helperRepository)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
            _helperRepository = helperRepository;
        }
    }
}
