

using Entity.Models.ModuleBase;
using Entity.Models.ModuleOperation;

namespace Entity.Models.ModelosParametros
{
    public class Grade : GenericModel
    {
     
        public string Description { get; set; } = string.Empty;
        public virtual ICollection<ExperienceGrade> ExperienceGrades { get; set; } = new List<ExperienceGrade>();
    }
}
