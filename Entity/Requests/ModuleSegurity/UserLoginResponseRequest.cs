namespace Entity.Requests.ModuleSegurity
{
    /// <summary>
    /// Response enviado al cliente tras un login exitoso.
    /// Contiene los datos del usuario autenticado, el token JWT y permisos de acceso.
    /// </summary>
    public class UserLoginResponseRequest
    {
        /// <summary>
        /// Identificador único del usuario autenticado.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Nombre de usuario usado en el login.
        /// </summary>
        public string UserName { get; set; } = string.Empty;

        /// <summary>
        /// Identificador de la persona asociada al usuario.
        /// </summary>
        public int PersonId { get; set; }

        /// <summary>
        /// Correo electrónico del usuario.
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Token JWT de acceso para las peticiones autenticadas.
        /// </summary>
        public string Token { get; set; } = string.Empty;

        /// <summary>
        /// Fecha y hora de expiración del token JWT.
        /// </summary>
        public DateTime ExpirationDate { get; set; }

        /// <summary>
        /// Lista de menús a los que el usuario tiene acceso.
        /// </summary>
        public List<MenuRequest> Menu { get; set; } = new();

        /// <summary>
        /// Lista de roles asociados al usuario autenticado.
        /// </summary>
        public List<string> Role { get; set; } = new();


        

    }
}
