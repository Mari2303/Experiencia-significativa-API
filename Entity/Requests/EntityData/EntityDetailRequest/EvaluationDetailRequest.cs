using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Dtos.ModuleOperational;
using Entity.Requests.ModuleOperation;

namespace Entity.Requests.EntityData.EntityDetailRequest
{
    public class EvaluationDetailRequest
    {
        public string TypeEvaluation { get; set; } = string.Empty;
        public string AccompanimentRole { get; set; } = string.Empty;
        public string Comments { get; set; } = string.Empty;
        public string EvaluationResult { get; set; } = string.Empty;
        // Traídos de Experience
        public string ExperienceName { get; set; } = string.Empty;
        //  Traído de Institution
        public string InstitutionName { get; set; } = string.Empty;
        //  Lista de criterios y linea tematica
        public List<EvaluationCriteriaRequest> CriteriaEvaluations { get; set; } = new();
        public List<string> ThematicLineNames { get; set; } = new();

        public string? UserName { get; set; }
        public string? Email { get; set; }




    }
}
