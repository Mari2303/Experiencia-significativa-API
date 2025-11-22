using Entity.Dtos.ModuleOperational;
using Entity.Models.ModelosParametros;
using Entity.Models.ModuleOperation;
using Entity.Requests.EntityData.EntityDetailRequest;
using Entity.Requests.ModuleOperation;
using Repository.Interfaces.IModuleBaseRepository;

namespace Repository.Interfaces.IModuleOperationRepository
{
    public interface IEvaluationRepository : IBaseModelRepository<Evaluation, EvaluationDTO, EvaluationRequest>
    {
        Task<Evaluation> AddEvaluationAsync(Evaluation evaluation);
        Task AddEvaluationCriteriaAsync(EvaluationCriteria criterEval);
        Task<Experience?> GetExperienceWithInstitutionAsync(int experienceId);
        Task UpdateCriteriaAsync(Criteria criteria);
        Task SaveChangesAsync();
        Task<Criteria?> GetCriteriaByIdAsync(int id);
        Task<EvaluationDetailRequest> GetEvaluationDetailAsync(int id);
        Task UpdateEvaluationPdfUrlAsync(int evaluationId, string pdfUrl);

        Task<Evaluation?> GetByExperienceAndTypeAsync(int experienceId, string typeEvaluation);
        Task<Evaluation> UpdateEvaluationAsync(Evaluation evaluation, List<EvaluationCriteria> newCriteria);

        Task<Evaluation?> GetEvaluationByIdTrackedAsync(int evaluationId);

        Task<IEnumerable<Experience>> GetExperiencesWithInitialEvaluationAsync();

        Task<IEnumerable<Experience>> GetExperiencesWithFinalEvaluationAsync();

        Task<IEnumerable<Experience>> GetExperiencesWithoutEvaluationAsync();
    }
}
