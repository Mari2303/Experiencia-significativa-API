using Entity.Requests.EntityData.EntityDataRequest;
using Entity.Requests.ModuleGeographic;
using Entity.Requests.ModuleOperation;
using Entity.Requests.ModulesParamer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Requests.EntityData.EntityDataRequest;
using Entity.Requests.ModuleGeographic;

namespace Entity.Requests.EntityData.EntityUpdateRequest
{
    public class ExperienceUpdateRequest
    {
        public int ExperienceId { get; set; }
         public string? NameExperiences { get; set; } = string.Empty;
        public string? Code { get; set; } = string.Empty;
        public string? ThematicLocation { get; set; } = string.Empty;
        public string? Developmenttime { get; set; }
        public string? Recognition { get; set; } = string.Empty;
        public string? Socialization { get; set; } = string.Empty;
        public int? StateExperienceId { get; set; }
        public int UserId { get; set; }

        public List<LeaderUpdateRequest> Leaders { get; set; }

        public InstitutionUpdateRequest InstitutionUpdate { get; set; }
        public List<DocumentUpdateRequest> DocumentsUpdate { get; set; }
        public List<ObjectiveUpdateRequest> ObjectivesUpdate { get; set; }
        public List<DevelopmentUpdateRequest> DevelopmentsUpdate { get; set; }
        public List<HistoryExperienceUpdateRequest> HistoryExperiencesUpdate { get; set; }
        public List<int>? PopulationGradeIds { get; set; }
        public List<int>? ThematicLineIds { get; set; }
        public List<GradeUpdateRequest> GradesUpdate { get; set; }
     


    }
}
