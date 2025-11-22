using AutoMapper;
using Entity.Context;
using Entity.Dtos.ModuleOperation;
using Entity.Models.ModuleOperation;
using Entity.Requests.ModuleOperation;
using Microsoft.Extensions.Configuration;
using Repository.Implementations.ModuleBaseRepository;
using Repository.Interfaces.IModuleOperationRepository;
using Utilities.Helper;

namespace Repository.Implementations.ModuleOperationRepository
{
    public class DevelopmentRepository : BaseModelRepository<Development, DevelopmentDTO, DevelopmentRequest>, IDevelopmentRepository
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IHelper<Development, DevelopmentDTO> _helperRepository;
        public DevelopmentRepository(ApplicationContext context, IMapper mapper, IHelper<Development, DevelopmentDTO> helperRepository, IConfiguration configuration) : base(context, mapper, configuration, helperRepository)
        {
            _context = context;
            _mapper = mapper;
            _helperRepository = helperRepository;
            _configuration = configuration;
        }
    }
}
