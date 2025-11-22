using API.Controllers.ModuleBaseController;
using AutoMapper;
using Entity.Dtos.ModuleOperational;
using Entity.Models.ModuleOperation;
using Entity.Requests.ModuleOperation;
using Service.Interfaces.IModuleBaseService;
using Service.Interfaces.ModelOperationService;

namespace API.Controllers.ModuleOperationController
{
    public class EvaluationCriteriaController : BaseModelController<EvaluationCriteria, EvaluationCriteriaDTO, EvaluationCriteriaRequest>
    {
        private readonly IEvaluationCriteriaService _evaluationCriteriaService;
        private readonly IMapper _mapper;
        public EvaluationCriteriaController(IBaseModelService<EvaluationCriteria, EvaluationCriteriaDTO, EvaluationCriteriaRequest> baseService, IEvaluationCriteriaService evaluationCriteriaService, IMapper mapper) : base(baseService, mapper)
        {
            _evaluationCriteriaService = evaluationCriteriaService;
            _mapper = mapper;
        }
    }
}
