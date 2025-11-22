

using Entity.Models.ModuleOperation;
using Entity.Requests.ModuleBase;

namespace Entity.Requests.ModuleOperation
{
    public class ObjectiveRequest : BaseRequest
    {
        public string DescriptionProblem { get; set; } = string.Empty;
        public string ObjectiveExperience { get; set; } = string.Empty;
        public string EnfoqueExperience { get; set; } = string.Empty;
        public string Methodologias { get; set; } = string.Empty;
        public string InnovationExperience { get; set; } = string.Empty;
        public string Pmi { get; set; }
        public string Nnaj { get; set; }
     

        public List<SupportInformationRequest> SupportInformations { get; set; }
        public List<MonitoringRequest> Monitorings { get; set; } 




    }
}
