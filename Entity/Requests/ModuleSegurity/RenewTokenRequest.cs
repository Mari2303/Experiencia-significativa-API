namespace Entity.Requests.ModuleSegurity
{
    /// <summary>
    /// Request que contiene el *refresh token* usado para renovar el token de acceso.
    /// </summary>
    public class RenewTokenRequest
    {
        /// <summary>
        /// Refresh token utilizado para obtener un nuevo access token 
        /// cuando el actual ha expirado.
        /// </summary>
        public string Token { get; set; } = string.Empty;
    }
}
