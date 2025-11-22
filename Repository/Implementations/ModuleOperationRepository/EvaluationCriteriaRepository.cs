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
    public class EvaluationCriteriaRepository : BaseModelRepository<EvaluationCriteria, EvaluationCriteriaDTO, EvaluationCriteriaRequest>, IEvaluationCriteriaRepository
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IHelper<EvaluationCriteria, EvaluationCriteriaDTO> _helperRepository;

        public EvaluationCriteriaRepository(ApplicationContext context, IMapper mapper, IHelper<EvaluationCriteria, EvaluationCriteriaDTO> helperRepository, IConfiguration configuration) : base(context, mapper, configuration, helperRepository)
        {
            _context = context;
            _mapper = mapper;
            _helperRepository = helperRepository;
            _configuration = configuration;
        }
    }
}
