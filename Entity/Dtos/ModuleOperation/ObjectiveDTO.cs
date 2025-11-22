using Entity.Dtos.ModuleBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entity.Dtos.ModuleOperational
{
    public class ObjectiveDTO : BaseDTO
    {
        public string DescriptionProblem { get; set; } = string.Empty;
        public string ObjectiveExperience { get; set; } = string.Empty;
        public string EnfoqueExperience { get; set; } = string.Empty;
        public string Methodologias { get; set; } = string.Empty;
        public string InnovationExperience { get; set; } = string.Empty;
        public string Pmi { get; set; }
        public string Nnaj { get; set; }
        public int ExperienceId { get; set; }
    }
}
