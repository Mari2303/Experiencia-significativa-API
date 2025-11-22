

namespace Utilities.Helper.Implementation
{
    public class PasswordHelper
    {
        public static void ValidatePassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new Exception("La contraseña no puede estar vacía.");
            if (password.Length < 8)
                throw new Exception("La contraseña debe tener al menos 8 caracteres.");
            if (!password.Any(char.IsUpper))
                throw new Exception("La contraseña debe contener al menos una letra mayúscula.");
            if (!password.Any(char.IsLower))
                throw new Exception("La contraseña debe contener al menos una letra minúscula.");
            if (!password.Any(char.IsDigit))
                throw new Exception("La contraseña debe contener al menos un número.");
            if (!password.Any(ch => !char.IsLetterOrDigit(ch)))
                throw new Exception("La contraseña debe contener al menos un carácter especial.");
        }
    }
}
