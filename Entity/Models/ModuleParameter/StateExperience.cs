
using Entity.Models.ModuleBase;
using Entity.Models.ModuleOperation;

namespace Entity.Models.ModelosParametros
{
    public class StateExperience : GenericModel
    {
        

        public virtual ICollection<Evaluation> Evaluations { get; set; } = new List<Evaluation>();
        public virtual ICollection<HistoryExperience> HistoryExperiences { get; set; } = new List<HistoryExperience>();
        public virtual ICollection<Experience> Experiences { get; set; } = new List<Experience>();
    }
}
