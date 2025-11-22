namespace Entity.Requests.ModuleSegurity
{
    /// <summary>
    /// Request usado para registrar un nuevo usuario junto con su información personal.
    /// </summary>
    public class UserRegisterRequest
    {
     

        /// <summary>
        /// Tipo de documento de la persona (ejemplo: CC, TI, PAS).
        /// </summary>
        public string DocumentType { get; set; } = string.Empty;

        /// <summary>
        /// Número de identificación único de la persona.
        /// </summary>
        public string IdentificationNumber { get; set; } = string.Empty;

        /// <summary>
        /// Primer nombre de la persona.
        /// </summary>
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Segundo nombre de la persona (opcional).
        /// </summary>
        public string? MiddleName { get; set; }

        /// <summary>
        /// Primer apellido de la persona.
        /// </summary>
        public string FirstLastName { get; set; } = string.Empty;

        /// <summary>
        /// Segundo apellido de la persona (opcional).
        /// </summary>
        public string? SecondLastName { get; set; }

        /// <summary>
        /// Código DANE de la institución (si aplica).
        /// </summary>
        public string CodeDane { get; set; } = string.Empty;

        /// <summary>
        /// Correo institucional de la persona.
        /// </summary>
        public string EmailInstitutional { get; set; } = string.Empty;

        /// <summary>
        /// Correo personal de la persona.
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Teléfono de la persona.
        /// </summary>
        public uint Phone { get; set; }


        // ============================
        // DATOS DE USUARIO
        // ============================

        /// <summary>
        /// Código único de referencia para el usuario.
        /// </summary>
        public string Code { get; set; } = string.Empty;

        /// <summary>
        /// Nombre de usuario único para autenticación.
        /// </summary>
        public string Username { get; set; } = string.Empty;

        /// <summary>
        /// Contraseña (en texto plano al llegar al backend, luego se debe encriptar).
        /// </summary>
        public string Password { get; set; } = string.Empty;

       
    }
}
