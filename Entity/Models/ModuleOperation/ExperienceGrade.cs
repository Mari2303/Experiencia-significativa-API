

using Entity.Models.ModelosParametros;
using Entity.Models.ModuleBase;

namespace Entity.Models.ModuleOperation
{
    public class ExperienceGrade : BaseModel
    {
        public int GradeId { get; set; }
        public int ExperienceId { get; set; }
        public string Description { get; set; } = string.Empty;
        public virtual Grade Grade { get; set; } = null!;
        public virtual Experience Experience { get; set; }= null!;

    }
}
