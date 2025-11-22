using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using Utilities.Email.Interfaces;

namespace Utilities.Email.Implements
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }
        public async Task SendExperiencesEmail(string emailReceptor, string recoveryCode)
        {
            var emailEmisor = _config["EmailSettings:SenderEmail"]!;
            var password = _config["EmailSettings:Password"]!;
            var host = _config["EmailSettings:SmtpServer"]!;
            var puerto = int.Parse(_config["EmailSettings:Port"]!);

            var smtpCliente = new SmtpClient(host, puerto)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(emailEmisor, password)
            };

            string asunto = "¡Recuperación de contraseña - Experiencias Significativas !";
            string cuerpoHtml = $@"
            <!DOCTYPE html>
            <html lang=""es"">
            <head>
            <meta charset=""UTF-8"">
            <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
            <title>Recuperación de Contraseña</title>
            <style>
                /* Estilos Responsive Básicos para el Código de Recuperación */
                .code-box {{
                    font-size: 28px;
                    font-weight: bold;
                    color: #0E7490; /* Azul fuerte de tu marca */
                    margin: 25px 0;
                    padding: 15px;
                    background-color: #F0F9FF; /* Azul muy claro */
                    border: 1px solid #BAE6FD; /* Borde azul claro */
                    border-radius: 8px;
                    text-align: center;
                    letter-spacing: 2px;
                }}
            </style>
            </head>
            <body style=""font-family: Arial, sans-serif; background-color: #F3F4F6; margin: 0; padding: 0;"">
            
            <table role=""presentation"" style=""width:100%; border-collapse:collapse;"" cellspacing=""0"" cellpadding=""0"">
                <tr>
                    <td align=""center"" style=""padding:40px 0 0 0;"">
                        <table role=""presentation"" style=""width:600px; border-collapse:collapse; background-color: #ffffff; border-radius: 12px; box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);"" cellspacing=""0"" cellpadding=""0"">
                            
                            <tr>
                                <td style=""padding: 30px 30px 10px 30px; background: linear-gradient(to right, #0F6799, #1793D1); border-radius: 12px 12px 0 0;"">
                                    <h1 style=""color: #ffffff; font-size: 24px; font-weight: bold; margin: 0; text-align: center;"">Gestión de Experiencias Significativas</h1>
                                </td>
                            </tr>
                            
                            <tr>
                                <td style=""padding: 35px 45px 35px 45px; text-align: center;"">
                                    
                                    <h2 style=""color: #0F6799; font-size: 24px; margin-top: 0; margin-bottom: 20px;""> Recupera tu Contraseña</h2>
                                    
                                    <p style=""font-size: 16px; color: #4B5563; line-height: 1.5;"">Hemos recibido una solicitud para restablecer tu contraseña. Utiliza el siguiente código de verificación para continuar con el proceso:</p>
                                    
                                    <div class=""code-box"">
                                    {recoveryCode} 
                                    </div>
                                    
                                    <p style=""font-size: 14px; color: #4B5563; line-height: 1.5; margin-bottom: 25px;"">Por favor, introduce este código en tu aplicación o página web. **Este código es válido por 10 minutos.**</p>
                                    
                                    <p style=""font-size: 14px; color: #EF4444; font-weight: bold;"">Si no solicitaste este cambio, puedes ignorar este correo de forma segura.</p>
                                </td>
                            </tr>
                            
                            <tr>
                                <td style=""padding: 20px 45px; background-color: #E5E7EB; border-radius: 0 0 12px 12px; text-align: center;"">
                                    <p style=""font-size: 12px; color: #6B7280; margin: 0;"">© Experiencias Significativas 2025 | Todos los derechos reservados.</p>
                                    <p style=""font-size: 12px; color: #6B7280; margin: 5px 0 0 0;"">Si tienes problemas, contacta con soporte técnico.</p>
                                </td>
                            </tr>
                            
                        </table>
                    </td>
                </tr>
            </table>
            </body>
            </html>";

            var mensaje = new MailMessage(emailEmisor, emailReceptor, asunto, cuerpoHtml)
            {
                IsBodyHtml = true
            };

            await smtpCliente.SendMailAsync(mensaje);
        }
    }
}