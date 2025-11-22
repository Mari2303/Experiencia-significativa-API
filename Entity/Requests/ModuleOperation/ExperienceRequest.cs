using Entity.Requests.EntityData.EntityCreateRequest;
using Entity.Requests.ModuleBase;
using Entity.Requests.ModuleGeographic;
using Entity.Requests.ModulesParamer;

namespace Entity.Requests.ModuleOperation
{
    public class ExperienceRequest : BaseRequest
    {
        public string NameExperiences { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string ThematicLocation { get; set; } = string.Empty;
        public DateTime Developmenttime { get; set; } = DateTime.Now;
        public string Recognition { get; set; } = string.Empty;
        public string Socialization { get; set; } = string.Empty;
        public int UserId { get; set; }
  

        public int StateExperienceId { get; set; }
        public string? StateExperience { get; set; }

      


        public InstitutionCreateRequest Institution { get; set; } = null!;
        public List<DocumentRequest> Documents { get; set; } 
        public List<ObjectiveRequest> Objectives { get; set; } 
        public List<LeaderRequest> Leaders { get; set; } 
        public List<DevelopmentRequest> Developments { get; set; }
        public List<HistoryExperienceRequest> HistoryExperiences { get; set; }
        public List<int> PopulationGradeIds { get; set; }
        public List<int> ThematicLineIds { get; set; }
        public List<GradeRequest> Grades { get; set; }
       

    }
}
