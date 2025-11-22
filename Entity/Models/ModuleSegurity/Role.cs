using Entity.Models.ModuleBase;

namespace Entity.Models.ModuleSegurity
{
   
    public class Role : GenericModel
    {
        
        public string Description { get; set; } = string.Empty;
       
        public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
       
        public virtual ICollection<RoleFormPermission> RoleFormPermissions { get; set; } = new List<RoleFormPermission>();

     
    }

}
