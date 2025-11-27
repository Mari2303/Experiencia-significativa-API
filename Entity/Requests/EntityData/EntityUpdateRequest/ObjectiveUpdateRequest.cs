using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Requests.EntityData.EntityUpdateRequest
{
    public class ObjectiveUpdateRequest
    {
        public string? DescriptionProblem { get; set; } = string.Empty;
        public string? ObjectiveExperience { get; set; } = string.Empty;
        public string? EnfoqueExperience { get; set; } = string.Empty;
        public string? Methodologias { get; set; } = string.Empty;
        public string? InnovationExperience { get; set; } = string.Empty;
        public string? Pmi { get; set; }
        public string? Nnaj { get; set; }
         
        public List<SupportInformationUpdateRequest> SupportInformationsUpdate { get; set; } 
        public List<MonitoringUpdateRequest> MonitoringsUpdate { get; set; }


    }
}
