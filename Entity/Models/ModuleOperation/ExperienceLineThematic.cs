

using Entity.Models.ModelosParametros;
using Entity.Models.ModuleBase;

namespace Entity.Models.ModuleOperation
{
    public class ExperienceLineThematic  : BaseModel
    {
        public int ExperienceId { get; set; } 
        public int LineThematicId { get; set; } 

        public virtual Experience Experience { get; set; } = null!;
        public virtual LineThematic LineThematic { get; set; } = null!;
    }
}
