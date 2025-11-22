
using Entity.Requests.EntityData.EntityDetailRequest;
using Entity.Requests.ModuleBase;

namespace Entity.Requests.ModuleOperation
{
    public class EvaluationRequest : BaseRequest
    {
        public string TypeEvaluation { get; set; } = string.Empty;
        public string Comments { get; set; } = string.Empty;
        public string AccompanimentRole { get; set; } = string.Empty;
        public string UrlEvaPdf { get; set; } = string.Empty;
        public int UserId { get; set; }
        public string? User { get; set; } = null!;
        public int ExperienceId { get; set; }
        public string? Experience { get; set; } = null!;

        public List<EvaluationCriteriaDetailRequest> EvaluationCriteriaDetail { get; set; } = new();

    }
}
