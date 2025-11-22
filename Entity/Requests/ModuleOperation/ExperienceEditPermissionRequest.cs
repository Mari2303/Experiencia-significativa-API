using Entity.Requests.ModuleBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Requests.ModuleOperation
{
    public class ExperienceEditPermissionRequest 
    {
        public int Id { get; set; }
        public int ExperienceId { get; set; }
        public string? Experience { get; set; } = null!;
        public int UserId { get; set; }
        public string? User { get; set; } = null!;
        public bool Approved { get; set; } = false;
        public DateTime? ExpiresAt { get; set; }




    }
}
