using Entity.Dtos.ModuleBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dtos.ModuleOperation
{
    public class SupportInformationDTO : BaseDTO
    {
        public string Summary { get; set; } = string.Empty;
        public string MetaphoricalPhrase { get; set; } = string.Empty;
        public string Testimony { get; set; } = string.Empty;
        public string FollowEvaluation { get; set; } = string.Empty;
        public int ObjectiveId { get; set; }

    }
}
