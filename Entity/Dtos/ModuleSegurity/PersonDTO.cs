using Entity.Dtos.ModuleBase;

namespace Entity.Dtos.ModuleSegurity
{
    /// <summary>
    /// Data Transfer Object for people information
    /// </summary>
    public class PersonDTO : BaseDTO
    {
        /// <summary>
        /// Person's document type
        /// </summary>
        public int DocumentType { get; set; }

        /// <summary>
        /// Unique code identifier for the person
        /// </summary>
        public string IdentificationNumber { get; set; } = string.Empty;

        /// <summary>
        /// Person's first name
        /// </summary>
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Person's middle name
        /// </summary>
        public string? MiddleName { get; set; } = string.Empty;

        /// <summary>
        /// Person's first last name
        /// </summary>
        public string FirstLastName { get; set; } = string.Empty;

        /// <summary>
        /// Person's secon last name
        /// </summary>
        public string? SecondLastName { get; set; } = string.Empty;

        /// <summary>
        /// Person's Email
        /// </summary>
        public string Email { get; set; } = string.Empty;

        public string CodeDane { get; set; } = string.Empty;

        public string EmailInstitutional { get; set; } = string.Empty;

        /// <summary>
        /// Person's Phone
        /// </summary>
        public uint Phone { get; set; }

    }
}