using Entity.Dtos.ModuleBase;
using System.ComponentModel.DataAnnotations;

namespace Entity.Dtos.ModuleSegurity
{
    /// <summary>
    /// Data Transfer Object for user information
    /// </summary>
    public class UserDTO : BaseDTO
    {
        /// <summary>
        /// Unique code identifier for the user 
        /// </summary>
        public string Code { get; set; } = string.Empty;
        /// <summary>
        /// The unique username for authentication
        /// </summary>
        public string Username { get; set; } = string.Empty;
        /// <summary>
        /// Hashed password for user authentication
        /// </summary>
        public string Password { get; set; } = string.Empty;
        /// <summary>
        /// /// Foreign key referencing the associated person
        /// </summary>
        public int PersonId { get; set; }

      


    }
}
