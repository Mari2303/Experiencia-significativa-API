using Entity.Requests.EntityData.EntityDetailRequest;
using Entity.Requests.ModuleOperation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Requests.EntityData.EntityUpdateRequest
{
    public class EvaluationUpdateRequest
    {
        public string TypeEvaluation { get; set; } = string.Empty;
        public string Comments { get; set; } = string.Empty;
        public string AccompanimentRole { get; set; } = string.Empty;
        public int UserId { get; set; }
        public int ExperienceId { get; set; }
        public List<EvaluationCriteriaDetailRequest> EvaluationCriteriaDetailRequest { get; set; } = new();
        public string EvaluationResult { get; set; } = string.Empty;
        
    }
}
