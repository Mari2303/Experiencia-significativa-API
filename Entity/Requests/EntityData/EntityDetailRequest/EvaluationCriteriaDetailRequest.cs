using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Requests.EntityData.EntityDetailRequest
{
    public class EvaluationCriteriaDetailRequest
    {
        public int CriteriaId { get; set; }  // id del criterio ya existente

        
        public List<int> Scores { get; set; } = new List<int>();       // valor otorgado por el evaluador

        public string DescriptionContribution { get; set; } = string.Empty;

    }
}
