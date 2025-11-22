using AutoMapper;
using Entity.Context;
using Entity.Dtos.ModuleOperational;
using Entity.Models.ModuleOperation;
using Entity.Requests.ModuleOperation;
using Microsoft.Extensions.Configuration;
using Repository.Implementations.ModuleBaseRepository;
using Repository.Interfaces.IModuleOperationRepository;
using Utilities.Helper;

namespace Repository.Implementations.ModuleOperationRepository
{
    public class ExperienceGradeRepository : BaseModelRepository<ExperienceGrade, ExperienceGradeDTO, ExperienceGradeRequest>, IExperienceGradeRepository
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IHelper<ExperienceGrade, ExperienceGradeDTO> _helperRepository;
        public ExperienceGradeRepository(ApplicationContext context, IMapper mapper, IHelper<ExperienceGrade, ExperienceGradeDTO> helperRepository, IConfiguration configuration) : base(context, mapper, configuration, helperRepository)
        {
            _context = context;
            _mapper = mapper;
            _helperRepository = helperRepository;
            _configuration = configuration;
        }
    }
}
