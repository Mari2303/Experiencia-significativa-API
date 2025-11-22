using Entity.Models.ModuleBase;
using Entity.Models.ModuleSegurity;

namespace Entity.Models
{
  
    public class Form : BaseModel
    {
      
        public string Name { get; set; } = string.Empty;
       
        public string Path { get; set; } = string.Empty;

     
        public string Description { get; set; } = string.Empty;

        public string Icon { get; set; } = string.Empty;

     
        public int Order { get; set; }

      
        public virtual ICollection<FormModule> FormModules { get; set; } = new List<FormModule>();

      
        public virtual ICollection<RoleFormPermission> RoleFormPermissions { get; set; } = new List<RoleFormPermission>();
    }
}