using Entity.Models.ModuleBase;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Models.ModuleSegurity
{
    /// <summary>
    /// Representa asociasion entre user y rol 
    /// </summary>
    /// 
    [Table("UserRoles")]
    public class UserRole : BaseModel
    {
       
        public int UserId { get; set; }
      
        public int RoleId { get; set; }
  
        public virtual User User { get; set; } = null!;

    
        public virtual Role Role { get; set; } = null!;
    }
}
