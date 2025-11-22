

using Entity.Models.ModuleBase;

namespace Entity.Models.ModuleOperation
{
    public class SupportInformation : BaseModel
    {
        public string Summary { get; set; } = string.Empty;
        public string MetaphoricalPhrase { get; set; } = string.Empty;
        public string Testimony {  get; set; } = string.Empty;
        public string FollowEvaluation {  get; set; } = string.Empty;
        public int ObjectiveId { get; set; }
        public virtual Objective Objective { get; set; } = null!;


    }
}
