using Entity.Dtos.ModuleBase;

namespace Entity.Dtos
{
    /// <summary>
    /// Represents a module in the security system
    /// </summary>
    public class ModuleDTO : BaseDTO
    {
        /// <summary>
        /// Module's name
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Module's description
        /// </summary>
        public string Description { get; set; } = string.Empty;
    }
}
