using Entity.Dtos.ModuleBase;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Dtos.ModuleSegurity
{
    /// <summary>
    /// Represents the association between a user and a role
    /// </summary>
    [Table("UserRoles")]
    public class UserRoleDTO : BaseDTO
    {
        /// <summary>
        /// Foreign key referencing the user
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Foreign key referencing the role
        /// </summary>
        public int RoleId { get; set; }
    }
}
