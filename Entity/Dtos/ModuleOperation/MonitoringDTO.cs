using Entity.Dtos.ModuleBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dtos.ModuleOperation
{
    public class MonitoringDTO : BaseDTO
    {
        public string MonitoringEvaluation { get; set; } = string.Empty;
        public string Result { get; set; } = string.Empty;
        public string Sustainability { get; set; } = string.Empty;
        public string Tranfer { get; set; } = string.Empty;
        public int ObjectiveId { get; set; }
    }
}
