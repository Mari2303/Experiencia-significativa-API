

using Entity.Models.ModuleBase;

namespace Entity.Models.ModuleOperation
{
    public class Objective : BaseModel
    {
        public string DescriptionProblem { get; set; } = string.Empty;
        public string ObjectiveExperience { get; set; } = string.Empty;
        public string EnfoqueExperience { get; set; } = string.Empty;
        public string Methodologias { get; set; } = string.Empty;
        public string Pmi { get; set; }
        public string Nnaj { get; set; }
        public string InnovationExperience { get; set; } = string.Empty;
        public int ExperienceId { get; set; }
        public virtual Experience Experience { get; set; } = null!;
        public ICollection<Monitoring> Monitorings { get; set; } = new List<Monitoring>();
        public ICollection<SupportInformation> SupportInformations { get; set; } = new List<SupportInformation>();
       
    }
}
