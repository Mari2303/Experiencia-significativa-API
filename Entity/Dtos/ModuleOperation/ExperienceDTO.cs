using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Dtos.ModuleBase;
using Entity.Models.ModuleOperation;

namespace Entity.Dtos.ModuleOperational
{
    public class ExperienceDTO : BaseDTO
    {
        public string NameExperiences { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty; 
        public string ThematicLocation { get; set; } = string.Empty;
        public DateTime Developmenttime { get; set; } = DateTime.Now;
        public string Recognition { get; set; } = string.Empty;
        public string Socialization { get; set; } = string.Empty;
        public int UserId { get; set; }
        public string? UrlPdf { get; set; }
        public int StateExperienceId { get; set; }
        public int InstitucionId { get; set; }
    }
}


