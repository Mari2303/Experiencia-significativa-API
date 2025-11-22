using Entity.Dtos.ModuleBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dtos.ModelosParametro
{
    public class GradeDTO : BaseDTO
    {
        public string Name { get; set; } = string.Empty; 
        public string Code { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
