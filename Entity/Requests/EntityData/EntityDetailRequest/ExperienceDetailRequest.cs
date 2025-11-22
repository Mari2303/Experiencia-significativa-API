using System.ComponentModel.DataAnnotations;
using Entity.Requests.EntityData.EntityDataRequest;

namespace Entity.Requests.EntityData.EntityDetailRequest
{
    public class ExperienceDetailRequest
    {
        [Required(ErrorMessage = "El ExperienceId es obligatorio")]
        public int ExperienceId { get; set; }

        public ExperienceInfoRequest ExperienceInfo { get; set; }
        
        public InstitutionInfoRequest InstitutionInfo { get; set; }
        public List<DocumentDetailRequest> DocumentInfo { get; set; } = new();

        public List<CriteriaDetailRequest> CriteriasDetail { get; set; } = new();



    }
}
