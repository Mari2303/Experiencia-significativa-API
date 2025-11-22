namespace Entity.Requests.ModuleSegurity
{
    /// <summary>
    /// Objeto de Transferencia de Datos (DTO) para la autenticación de un usuario
    /// </summary>
    public class AuthenticationRequest
    {
        /// <summary>
        /// El nombre de usuario único para la autenticación
        /// </summary>
        public string Username { get; set; } = string.Empty;

        /// <summary>
        /// La contraseña para la autenticación del usuario
        /// </summary>
        public string Password { get; set; } = string.Empty;
    }
}
