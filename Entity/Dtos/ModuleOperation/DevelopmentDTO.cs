using Entity.Dtos.ModuleBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dtos.ModuleOperation
{
    public class DevelopmentDTO : BaseDTO
    {
        public string CrossCuttingProject { get; set; } = string.Empty;
        public string Population { get; set; } = string.Empty;
        public string PedagogicalStrategies { get; set; } = string.Empty;
        public string Coverage { get; set; } = string.Empty;
        public string CovidPandemic { get; set; } = string.Empty;
        public int ExperienceId { get; set; }

    }
}
