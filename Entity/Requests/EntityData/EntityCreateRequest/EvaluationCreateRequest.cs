using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Requests.EntityData.EntityDetailRequest;
using Entity.Requests.ModuleOperation;

namespace Entity.Requests.EntityData.EntityCreateRequest
{
    public class EvaluationCreateRequest
    {
        public string TypeEvaluation { get; set; } = string.Empty;
        public string Comments { get; set; } = string.Empty;
        public string AccompanimentRole { get; set; } = string.Empty;
        public int UserId { get; set; }
        
        public int ExperienceId { get; set; }
       

        public List<EvaluationCriteriaDetailRequest> EvaluationCriteriaDetail { get; set; } = new();
    }
}
