
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using Entity.Models.ModelosParametros;
using Entity.Models.ModuleBase;


namespace Entity.Models.ModuleOperation
{
    public class Experience : BaseModel
    {
        public string NameExperiences { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string ThematicLocation { get; set; } = string.Empty;
        public string Developmenttime { get; set; } 
        public string Recognition { get; set; } = string.Empty;
        public string Socialization { get; set; } = string.Empty;

        public string? UrlPdf {  get; set; } = string.Empty;

        public int StateExperienceId { get; set; }
        public virtual StateExperience StateExperience { get; set; } = null!;
        public int UserId { get; set; }
        public virtual User User { get; set; } = null!;
        public int InstitucionId { get; set; }
        public virtual Institution Institution {  set; get; } = null!;

      

        public ICollection<Document> Documents { get; set; } = new List<Document>();
        public ICollection<ExperienceLineThematic> ExperienceLineThematics { get; set; } = new List<ExperienceLineThematic>();
        public ICollection<ExperienceGrade> ExperienceGrades { get; set; } = new List<ExperienceGrade>();
        public ICollection<Objective> Objectives { get; set; } = new List<Objective>();
        public ICollection<ExperiencePopulation> ExperiencePopulations { get; set;} = new List<ExperiencePopulation>();
        public ICollection<Evaluation>  Evaluations { get; set; } = new List<Evaluation>();
        public ICollection<HistoryExperience> HistoryExperiences { get; set; } = new List<HistoryExperience>();
        public ICollection<Development> Developments { get; set; } = new List<Development>();
        public ICollection<Leader> Leaders { get; set; } = new List<Leader>();



      




    }
}
