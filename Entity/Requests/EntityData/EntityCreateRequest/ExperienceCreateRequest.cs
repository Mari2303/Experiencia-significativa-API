using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Requests.ModuleOperation;
using Entity.Requests.ModulesParamer;

namespace Entity.Requests.EntityData.EntityCreateRequest
{
    public class ExperienceCreateRequest
    {
        public string NameExperiences { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string ThematicLocation { get; set; } = string.Empty;
        public string Developmenttime { get; set; } 
        public string Recognition { get; set; } = string.Empty;
        public string Socialization { get; set; } = string.Empty;
        public int UserId { get; set; }
       

        public int StateExperienceId { get; set; }
 


        public InstitutionCreateRequest Institution { get; set; } = null!;
        public List<DocumentCreateRequest> Documents { get; set; }
        public List<ObjectiveCreateRequest> Objectives { get; set; }
        public List<LeaderCreateRequest> Leaders { get; set; }
        public List<DevelopmentCreateRequest> Developments { get; set; }
        public List<HistoryExperienceCreateRequest> HistoryExperiences { get; set; }
        public List<int> PopulationGradeIds { get; set; }
        public List<int> ThematicLineIds { get; set; }
        public List<GradeCreateRequest> Grades { get; set; }
    }
}
