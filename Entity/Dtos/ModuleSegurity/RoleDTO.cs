using Entity.Dtos.ModuleBase;

namespace Entity.Dtos
{
    /// <summary>
    /// Data Transfer Object for rol information
    /// </summary>
    public class RoleDTO : GenericDTO
    {
        /// <summary>
        /// Description of the role's purpose and scope
        /// </summary>
        public string Description { get; set; } = string.Empty;
    }
}
