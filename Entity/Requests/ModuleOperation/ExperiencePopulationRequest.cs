
using Entity.Requests.ModuleBase;

namespace Entity.Requests.ModuleOperation
{
    public class ExperiencePopulationRequest : BaseRequest
    {
        public int ExperienceId { get; set; }
        public int PopulationGradeId { get; set; }
        public string? Experience { get; set; } = null!;
        public string? PopulationGrade { get; set; } = null!;
    }
}
