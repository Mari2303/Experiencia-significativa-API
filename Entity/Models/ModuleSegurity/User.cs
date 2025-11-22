using System.ComponentModel.DataAnnotations;
using Entity.Models.ModuleBase;
using Entity.Models.ModuleOperation;
using Entity.Models.ModuleSegurity;

namespace Entity.Models
{
    
    public class User : BaseModel
    {
        public string Code { get; set; } = string.Empty;


        public string Username { get; set; } = string.Empty;

        public int PersonId { get; set; }

        [Required]
        public string Password { get; set; } = string.Empty;

       
        public virtual Person Person { get; set; } = null!;

        public string? RecoveryCode { get; set; }        // Código temporal enviado por correo
        public DateTime? RecoveryCodeExpiration { get; set; } // Hora de expiración del código

     


        public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
        public virtual ICollection<Experience> Experiences { get; set; } = new List<Experience>();
        public virtual ICollection<Evaluation> Evaluations { get; set; } = new List<Evaluation>();
        public virtual ICollection<HistoryExperience> HistoryExperiences { get; set; } = new List<HistoryExperience>();
    }
}
