

using Entity.Models.ModuleBase;
using System.Text.Json.Serialization;

namespace Entity.Models.ModuleOperation
{
    public class Document : BaseModel
    {
     
      
      

        public string Name { get; set; } = string.Empty;
        public string UrlLink { get; set; } = string.Empty;
        public string UrlPdf { get; set; } = string.Empty;
        public string UrlPdfExperience {  get; set; } = string.Empty;
        public int ExperienceId { get; set; }
        public virtual Experience Experience { get; set; } = null!;
    }
}
