

using Entity.Requests.ModuleBase;

namespace Entity.Requests.ModuleOperation
{
    public class ExperienceLineThematicRequest : BaseRequest
    {
        public int ExperienceId { get; set; }
        public int LineThematicId { get; set; }

        public string? Experience { get; set; } = null;
        public string? LineThematic { get; set; } = null;
    }
}
