

using Entity.Models.ModuleBase;

namespace Entity.Models.ModuleOperation
{
    public class Evaluation : BaseModel
    {
        public string TypeEvaluation { get; set; } = string.Empty;
        public string Comments { get; set; } = string.Empty;
        public string AccompanimentRole { get; set; } = string.Empty;
        public string EvaluationResult { get; set; } = string.Empty;

        public string UrlEvaPdf { get; set; } = string.Empty ;
        public int UserId { get; set; }
        public virtual User User { get; set; } = null!;
        public int ExperienceId { get; set; }
        public virtual Experience Experience { get; set; } = null!;
        public ICollection<EvaluationCriteria> EvaluationCriterias { get; set; } = new List<EvaluationCriteria>();
    }
}
