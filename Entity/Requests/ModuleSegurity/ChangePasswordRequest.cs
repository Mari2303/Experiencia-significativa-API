using System.ComponentModel.DataAnnotations;

namespace Entity.Requests.ModuleSegurity
{
    /// <summary>
    /// Petición para cambiar la contraseña de un usuario
    /// </summary>
    public class ChangePasswordRequest
    {
        /// <summary>
        /// Identificador único del usuario
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Contraseña actual del usuario (para verificación)
        /// </summary>
        [Required(ErrorMessage = "La actual contraseña es obligatoria")]
        public string CurrentPassword { get; set; } = string.Empty;

        /// <summary>
        /// Nueva contraseña del usuario
        /// </summary>
        [Required(ErrorMessage = "La nueva contraseña es obligatoria")]
        [MinLength(8, ErrorMessage = "La contraseña debe tener al menos 8 caracteres")]
        public string NewPassword { get; set; } = string.Empty;

        /// <summary>
        /// Confirmación de la nueva contraseña
        /// </summary>
        [Required(ErrorMessage = "Debe confirmar la contraseña")]
        [Compare("NewPassword", ErrorMessage = "Las contraseñas no coinciden")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
