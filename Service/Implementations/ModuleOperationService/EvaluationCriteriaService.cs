using Entity.Dtos.ModuleOperational;
using Entity.Models.ModuleOperation;
using Entity.Requests.ModuleOperation;
using Repository.Interfaces.IModuleOperationRepository;
using Service.Implementations.ModuleBaseService;
using Service.Interfaces.ModelOperationService;

namespace Service.Implementations.ModelOperationService
{
    public class EvaluationCriteriaService : BaseModelService<EvaluationCriteria, EvaluationCriteriaDTO, EvaluationCriteriaRequest>, IEvaluationCriteriaService
    {
        private readonly IEvaluationCriteriaRepository _evaluationCriteriaRepository;

        public EvaluationCriteriaService(IEvaluationCriteriaRepository evaluationCriteriaRepository) : base(evaluationCriteriaRepository)
        {
            _evaluationCriteriaRepository = evaluationCriteriaRepository;
        }
    }
}
