
using Utilities.Email.Interfaces;


public class AccountNotificationService
{
    private readonly IBrevoEmailService _brevoEmailService;

    public AccountNotificationService(IBrevoEmailService brevoEmailService)
    {
        _brevoEmailService = brevoEmailService;
    }

    public async Task NotifyAccountActivatedAsync(string email, string fullName)
    {
        var parameters = new Dictionary<string, object>
        {
            { "userName", fullName }
        };

        int templateId = 1; // el ID de la plantilla de Brevo

        await _brevoEmailService.SendEmailAsync(
            to: email,
            templateId: templateId,
            parameters: parameters
        );
    }
}
