using Entity.Dtos.ModuleOperational;
using Entity.Models.ModuleOperation;
using Entity.Requests.EntityData.EntityCreateRequest;
using Entity.Requests.EntityData.EntityDetailRequest;
using Entity.Requests.EntityData.EntityUpdateRequest;
using Entity.Requests.ModuleOperation;
using Service.Interfaces.IModuleBaseService;
using System.Threading.Tasks;

namespace Service.Interfaces.ModelOperationService
{
    public interface IEvaluationService : IBaseModelService<Evaluation, EvaluationDTO, EvaluationRequest>
    {
        Task<EvaluationDetailRequest> CreateEvaluationAsync(EvaluationCreateRequest request);

        Task<EvaluationDetailRequest> UpdateEvaluationAsync(int evaluationId, EvaluationUpdateRequest request);

        Task<string> GenerateAndAttachPdfAsync(int evaluationId);

        Task<IEnumerable<Experience>> FilterInitialEvaluationAsync();

        Task<IEnumerable<Experience>> FilterFinalEvaluationAsync();

        Task<IEnumerable<Experience>> FilterWithoutEvaluationAsync();


    }
}
