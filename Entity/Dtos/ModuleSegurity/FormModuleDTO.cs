using Entity.Dtos.ModuleBase;

namespace Entity.Dtos.ModuleSegurity
{
    /// <summary>
    /// Represents the association between a form and a module
    /// </summary>
    public class FormModuleDTO : BaseDTO
    {
        /// <summary>
        /// Foreign key referencing the form
        /// </summary>
        public int FormId { get; set; }
        /// <summary>
        /// Foreign key referencing the module
        /// </summary>
        public int ModuleId { get; set; }
    }
}
