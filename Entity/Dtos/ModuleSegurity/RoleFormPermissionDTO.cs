using Entity.Dtos.ModuleBase;

namespace Entity.Dtos.ModuleSegurity
{
    /// <summary>
    /// Represents the association between a role, a form, and a specific permission
    /// </summary>
    public class RoleFormPermissionDTO : BaseDTO
    {
        /// <summary>
        /// Foreign key referencing the role
        /// </summary>
        public int RoleId { get; set; }
        /// <summary>
        /// Foreign key referencing the form
        /// </summary>
        public int FormId { get; set; }
        /// <summary>
        /// Foreign key referencing the permission
        /// </summary>
        public int PermissionId { get; set; }
    }
}
