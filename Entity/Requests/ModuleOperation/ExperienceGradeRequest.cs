using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Models.ModelosParametros;
using Entity.Models.ModuleOperation;
using Entity.Requests.ModuleBase;

namespace Entity.Requests.ModuleOperation
{
    public class ExperienceGradeRequest : BaseRequest
    {
        public int GradeId { get; set; }
        public int ExperienceId { get; set; }
        public string Description { get; set; } = string.Empty;
        public string? Grade { get; set; } = null!;
        public string? Experience { get; set; } = null!;
    }
}
