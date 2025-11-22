using Entity.Dtos.ModuleBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dtos.ModuleOperational
{
    public class ExperienceLineThematicDTO : BaseDTO
    {
        public int ExperienceId { get; set; }
        public int LineThematicId { get; set; }
    }
}
