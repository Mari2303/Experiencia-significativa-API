using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using sib_api_v3_sdk.Api;
using sib_api_v3_sdk.Client;
using sib_api_v3_sdk.Model;
using Utilities.Email.Interfaces;

namespace Utilities.Email.Implement
{
    public class BrevoEmailService : IBrevoEmailService
    {
        private readonly string _apiKey;
        private readonly ILogger<BrevoEmailService> _logger;
        private readonly IConfiguration _configuration;

        public BrevoEmailService(IConfiguration configuration, ILogger<BrevoEmailService> logger)
        {
            _configuration = configuration;
            _logger = logger;

            _apiKey = configuration["Brevo:ApiKey"]
                ?? throw new InvalidOperationException("Brevo API Key no configurada en appsettings.json");

            // Configura la API Key global una sola vez
            Configuration.Default.ApiKey.Clear();
            Configuration.Default.ApiKey.Add("api-key", _apiKey);
        }

      
        /// <summary>
        /// Envía un correo basado en una plantilla de Brevo.
        /// </summary>
        public async Task<bool> SendEmailAsync(string to, int templateId, Dictionary<string, object>? parameters = null)
        {
            try
            {
                var apiInstance = new TransactionalEmailsApi();

                var sendSmtpEmail = new SendSmtpEmail(
                    sender: new SendSmtpEmailSender("Experiencia significativas", "mariaalejan1080@gmail.com"),
                    to: new List<SendSmtpEmailTo> { new SendSmtpEmailTo(to) },
                    templateId: templateId,
                    _params: parameters
                );

                var result = await apiInstance.SendTransacEmailAsync(sendSmtpEmail);
                _logger.LogInformation(" Correo de plantilla {TemplateId} enviado a {Email}", templateId, to);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, " Error al enviar plantilla {TemplateId} a {Email}", templateId, to);
                return false;
            }
        }
    }
}
