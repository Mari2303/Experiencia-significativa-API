

namespace Utilities.Email.Interfaces
{
    public interface IEmailService
    {
        Task SendExperiencesEmail(string emailReceptor, string recoveryCode);
      


    }
}
