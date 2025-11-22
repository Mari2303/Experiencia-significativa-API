using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Requests.EntityData.EntityCreateRequest
{
    public class MonitoringCreateRequest
    {
        public string MonitoringEvaluation { get; set; } = string.Empty;
        public string Result { get; set; } = string.Empty;
        public string Sustainability { get; set; } = string.Empty;
        public string Tranfer { get; set; } = string.Empty;


    }
}
