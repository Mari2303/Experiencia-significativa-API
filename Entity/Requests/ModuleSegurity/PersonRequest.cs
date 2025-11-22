using Entity.Requests.ModuleBase;
using System.ComponentModel.DataAnnotations;

namespace Entity.Requests.ModuleSegurity
{
    public class PersonRequest : BaseRequest
    {
        [Required(ErrorMessage = "El tipo de documento es obligatorio")]
        public string DocumentType { get; set; } = string.Empty;


        [Required(ErrorMessage = "El número de identificación es obligatorio")]
        [StringLength(12, MinimumLength = 5, ErrorMessage = "El número de identificación debe tener entre 5 y 12 caracteres")]
        public string IdentificationNumber { get; set; } = string.Empty;


        [Required(ErrorMessage = "El primer nombre es obligatorio")]
        [StringLength(50, ErrorMessage = "El primer nombre no puede exceder 50 caracteres")]
        public string FirstName { get; set; } = string.Empty;


        [StringLength(50, ErrorMessage = "El segundo nombre no puede exceder 50 caracteres")]
        public string? MiddleName { get; set; } = string.Empty;


        [Required(ErrorMessage = "El primer apellido es obligatorio")]
        [StringLength(50, ErrorMessage = "El primer apellido no puede exceder 50 caracteres")]
        public string FirstLastName { get; set; } = string.Empty;


        [StringLength(50, ErrorMessage = "El segundo apellido no puede exceder 50 caracteres")]
        public string? SecondLastName { get; set; } = string.Empty;



        [Required(ErrorMessage = "El código DANE es obligatorio")]
        [StringLength(12, ErrorMessage = "El código DANE no puede exceder 12 caracteres")]
        public string CodeDane { get; set; } = string.Empty;


        [Required(ErrorMessage = "El correo institucional es obligatorio")]
        public string EmailInstitutional { get; set; } = string.Empty;



        [Required(ErrorMessage = "El correo institucional es obligatorio")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "El teléfono es obligatorio")]
       
        public uint Phone { get; set; }
    }
}
