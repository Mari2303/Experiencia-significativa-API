
using Entity.Models.ModuleBase;
using Entity.Models.ModuleOperation;

namespace Entity.Models.ModelosParametros
{
    public class Criteria : GenericModel
    {
     

        public ICollection<EvaluationCriteria> EvaluationCriterias { get; set; } = new List<EvaluationCriteria>();
    }
}
