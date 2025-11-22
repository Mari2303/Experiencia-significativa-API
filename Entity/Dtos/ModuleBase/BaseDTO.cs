namespace Entity.Dtos.ModuleBase
{
    /// <summary>
    /// Data Transfer Object for entity information
    /// </summary>
    public class BaseDTO
    {
        /// <summary>
        /// The unique identifier for the entity
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Indicates if the entity is currently active in the system
        /// </summary>
       public bool State { get; set; }
        /// <summary>
        /// Date and time when the entity was created
        /// </summary>
    //    public DateTime? CreatedAt { get; set; }
        /// <summary>
        /// Date and time when the entity was last deleted
        /// </summary>
     //   public DateTime? DeletedAt { get; set; }
    }
}
