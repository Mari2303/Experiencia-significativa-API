using AutoMapper;
using Entity.Context;
using Entity.Dtos.ModuleGeographic;
using Entity.Models.ModuleGeographic;
using Entity.Requests.ModuleGeographic;
using Microsoft.Extensions.Configuration;
using Repository.Implementations.ModuleBaseRepository;
using Repository.Interfaces.IModuleGeographicRepository;
using Utilities.Helper;

namespace Repository.Implementations.ModuleGeographicRepository
{
    public class DepartamentRepository : BaseModelRepository<Departament, DepartamentDTO, DepartamentRequest>, IDepartamentRepository
    {

        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IHelper<Departament, DepartamentDTO> _helperRepository;
        public DepartamentRepository(ApplicationContext context, IMapper mapper, IHelper<Departament, DepartamentDTO> helperRepository, IConfiguration configuration) : base(context, mapper, configuration, helperRepository)
        {
            _context = context;
            _mapper = mapper;
            _helperRepository = helperRepository;
            _configuration = configuration;
        }
    }
}
