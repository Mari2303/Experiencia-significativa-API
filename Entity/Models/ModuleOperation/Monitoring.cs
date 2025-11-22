

using Entity.Models.ModuleBase;

namespace Entity.Models.ModuleOperation
{
    public class Monitoring : BaseModel
    {

        public string MonitoringEvaluation { get; set; } = string.Empty;
        public string Result { get; set; } = string.Empty;
        public string Sustainability {  get; set; } = string.Empty;
        public string Tranfer {  get; set; } = string.Empty;
        public int ObjectiveId {  get; set; }
        public virtual Objective Objective { get; set; } = null!; 



    }
}
