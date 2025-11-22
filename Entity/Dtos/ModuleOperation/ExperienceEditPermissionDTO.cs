using Entity.Dtos.ModuleBase;
using Entity.Models.ModuleBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dtos.ModuleOperation
{
    public class ExperienceEditPermissionDTO 
    {
        public int Id { get; set; }
        public int ExperienceId { get; set; }
        public string ExperienceName { get; set; } = string.Empty;
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public DateTime? ExpiresAt { get; set; }
        public bool Approved { get; set; } = false;




    }
}
