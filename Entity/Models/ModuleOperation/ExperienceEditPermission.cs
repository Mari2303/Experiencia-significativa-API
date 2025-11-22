using Entity.Models.ModuleBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models.ModuleOperation
{
    public class ExperienceEditPermission
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int ExperienceId { get; set; }
        public virtual Experience Experience { get; set; } = null!;
        public int UserId { get; set; }
        public virtual User User { get; set; } = null!;
        public DateTime? ExpiresAt { get; set; }
        public bool Approved { get; set; } = false;

    }
}
