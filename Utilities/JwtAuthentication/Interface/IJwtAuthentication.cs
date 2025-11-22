namespace Utilities.JwtAuthentication
{
    /// <summary>
    /// Interfaz que define operaciones para la autenticación JWT y el cifrado de contraseñas.
    /// </summary>
    public interface IJwtAuthentication
    {
        /// <summary>
        /// Autentica a un usuario en función de su nombre de usuario y contraseña.
        /// </summary>
        /// <param name="user">El nombre de usuario del usuario.</param>
        /// <param name="password">La contraseña del usuario.</param>
        /// <param name="role">El rol del usuario.</param>
        /// <param name="userId">El ID del usuario.</param>
        /// <returns>Un token JWT si la autenticación es exitosa.</returns>
        string Authenticate(string user, string password, string role, int userId);

        /// <summary>
        /// Cifra una contraseña utilizando el algoritmo MD5.
        /// </summary>
        /// <param name="password">La contraseña a cifrar.</param>
        /// <returns>El hash MD5 de la contraseña.</returns>
        string EncryptMD5(string password);

        /// <summary>
        /// Renueva un token JWT existente creando un nuevo token con los mismos claims pero con una nueva fecha de expiración.
        /// </summary>
        /// <param name="existingToken">El token JWT existente que se desea renovar.</param>
        /// <returns>Un nuevo token JWT con los mismos claims pero con nueva fecha de expiración, o un mensaje de error si la renovación falla.</returns>
        string RenewToken(string existingToken);
    }
}
