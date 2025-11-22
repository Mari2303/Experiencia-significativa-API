
using Entity.Models.ModuleBase;
using Entity.Models.ModuleOperation;

namespace Entity.Models.ModelosParametros
{
    public class LineThematic : GenericModel
    {
       

        public virtual ICollection<ExperienceLineThematic> ExperienceLineThematics { get; set; } = new List<ExperienceLineThematic>();

    }
}
