namespace Entity.Dtos.ModuleBase
{
    /// <summary>
    /// Data Transfer Object for entity information
    /// </summary>
    public class GenericDTO : BaseDTO
    {
        /// <summary>
        /// Unique code identifier for the entity 
        /// </summary>
        public string Code { get; set; } = string.Empty;
        /// <summary>
        /// The name of the entity
        /// </summary>
        public string Name { get; set; } = string.Empty;
    }
}
