using Entity.Models.ModuleBase;

namespace Entity.Models.ModuleSegurity
{
   
    public class RoleFormPermission : BaseModel
    {
        
        public int RoleId { get; set; }
       
        public int FormId { get; set; }
      
        public int PermissionId { get; set; }
      
        public virtual Role Role { get; set; } = null!;
        
        public virtual Form Form { get; set; } = null!;
      
        public virtual Permission Permission { get; set; } = null!;
    }
}
