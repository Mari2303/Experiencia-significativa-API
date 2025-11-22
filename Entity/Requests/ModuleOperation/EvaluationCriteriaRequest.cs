using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Models.ModelosParametros;
using Entity.Models.ModuleOperation;
using Entity.Requests.ModuleBase;

namespace Entity.Requests.ModuleOperation
{
    public class EvaluationCriteriaRequest : BaseRequest
    {
        public int Score { get; set; }
        public int EvaluationId { get; set; }
        public int CriteriaId { get; set; }
        public string? Evaluation { get; set; } = null!;
        public string? Criteria { get; set; } = null!;

        public string? DescriptionContribution { get; set; }




    }
}
