

using Entity.Dtos.ModuleBase;

namespace Entity.Dtos.ModuleOperational
{
    public class EvaluationCriteriaDTO : BaseDTO
    {
        public int Score { get; set; }
        public int EvaluationId { get; set; }
        public int CriteriaId { get; set; }
       public string? DescriptionContribution { get; set; }
    }
}
