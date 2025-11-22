using Entity.Dtos.ModuleBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dtos.ModuleOperational
{
    public class ExperienceGradeDTO : BaseDTO
    {
        public int GradeId { get; set; }
        public string Description { get; set; } = string.Empty;
        public int ExperienceId { get; set; }
    }
}
