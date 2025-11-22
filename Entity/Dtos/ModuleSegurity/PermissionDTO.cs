using Entity.Dtos.ModuleBase;

namespace Entity.Dtos.ModuleSegurity
{
    /// <summary>
    /// Represents a specific permission that can be granted to roles for forms
    /// </summary>
    public class PermissionDTO : GenericDTO
    {
        /// <summary>
        /// Description of what the permission allows
        /// </summary>
        public string Description { get; set; } = string.Empty;
    }
}
