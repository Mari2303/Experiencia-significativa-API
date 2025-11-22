

using Entity.Models.ModuleBase;

namespace Entity.Models.ModuleOperation
{
    public class Leader : BaseModel
    {
        public string Code { get; set; } = string.Empty;
        public string NameLeaders { get; set; } = string.Empty;
        public string  IdentityDocument { get; set; } = string.Empty ;
        public string Email {get; set;} = string.Empty ;
        public string Position {get; set; } = string.Empty ;
        public uint Phone { get; set; }
        public int ExperienceId { get; set; }
        public virtual Experience Experience { get; set; } = null!;

      
    }
}
