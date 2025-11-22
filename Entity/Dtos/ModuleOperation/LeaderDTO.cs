using Entity.Dtos.ModuleBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dtos.ModuleOperation
{
    public class LeaderDTO : BaseDTO
    {
        public string Code { get; set; } = string.Empty;
        public string NameLeaders { get; set; } = string.Empty;
        public string IdentityDocument { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public uint Phone { get; set; }
        public int ExperienceId { get; set; }


    }
}
