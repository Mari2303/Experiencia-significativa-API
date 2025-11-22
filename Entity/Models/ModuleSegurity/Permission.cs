using Entity.Models.ModuleBase;

namespace Entity.Models.ModuleSegurity
{
 
    public class Permission : GenericModel
    {
     
        public string Description { get; set; } = string.Empty;
       
        public virtual ICollection<RoleFormPermission> RoleFormPermissions { get; set; } = new List<RoleFormPermission>();
    }
}
