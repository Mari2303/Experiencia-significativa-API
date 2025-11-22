

using Entity.Models.ModelosParametros;
using Entity.Models.ModuleBase;

namespace Entity.Models.ModuleOperation
{
    public  class HistoryExperience : BaseModel
    {

        public string Action { get; set; } = string.Empty;
        public string TableName { get; set; } = string.Empty;
        public int ExperienceId { get; set; }
        public virtual Experience Experience { get; set; } = null!;
        public int UserId { get; set; }
        public virtual User User { get; set; } = null!;
       
    }
}
