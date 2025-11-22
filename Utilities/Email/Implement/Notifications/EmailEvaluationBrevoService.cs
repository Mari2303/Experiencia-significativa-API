using System.Text;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Utilities.Email.Interfaces;

public class EmailEvaluationBrevoService : IEmailEvaluationBrevoService
{
    private readonly HttpClient _client;
    private readonly string _fromEmail;
    private readonly string _fromName;

    public EmailEvaluationBrevoService(IConfiguration configuration)
    {
        var brevoSection = configuration.GetSection("Brevo");

        string apiKey = brevoSection["ApiKey"];
        _fromEmail = brevoSection["FromEmail"];
        _fromName = brevoSection["FromName"];

        _client = new HttpClient
        {
            BaseAddress = new Uri("https://api.brevo.com/v3/")
        };
        _client.DefaultRequestHeaders.Add("api-key", apiKey);
    }

    public async Task SendEvaluationResultEmailAsync(string toEmail, string userName, string evaluationResult)
    {
        // Colores dinámicos según el resultado (manteniendo la lógica y valores originales)
        string color = evaluationResult switch
        {
            "Naciente" => "#ff9f43",      // naranja
            "Creciente" => "#1793D1",     // Azul corporativo (en lugar del azul genérico #3498db)
            "Inspiradora" => "#27ae60",   // verde
            _ => "#7f8c8d"                // gris neutro
        };

        // Color base de tu aplicación web para fondos y acentos principales
        string primaryBlue = "#0F6799";
        string lightGray = "#F9FAFB";
        string darkText = "#1F2937";

        string message = evaluationResult switch
        {
            "Naciente" => "Tu evaluación se encuentra en la etapa **Naciente**. ¡Sigue esforzándote, vas por buen camino y tienes potencial de crecimiento!",
            "Creciente" => "Tu resultado es **Creciente**. ¡Estás avanzando de forma consistente, felicidades! Mantén el ritmo para alcanzar la excelencia.",
            "Inspiradora" => "Tu evaluación fue **Inspiradora**. ¡Increíble trabajo! Tu desempeño es ejemplar y superó las expectativas.",
            _ => $"Tu resultado de evaluación es: **{evaluationResult}**."
        };

        // Plantilla HTML mejorada con estilos de tarjetas y tu marca
        string html = $@"
        <div style='background-color:{lightGray}; padding:40px 0; font-family:Arial, sans-serif; text-align:center;'>
            <table role='presentation' style='width:100%; border-collapse:collapse;' cellspacing='0' cellpadding='0'>
                <tr>
                    <td align='center' style='padding:0;'>
                        <table role='presentation' style='width:600px; max-width:100%; border-collapse:collapse; background-color: #ffffff; border-radius:12px; overflow:hidden; box-shadow:0 4px 15px rgba(0,0,0,0.1);' cellspacing='0' cellpadding='0'>
                            
                            <tr>
                                <td style='padding: 20px 30px; background-color:{color}; color:white; text-align:center;'>
                                    <h1 style='margin:0; font-size:26px; font-weight:bold;'>Resultado de Evaluación</h1>
                                    <p style='margin:5px 0 0; font-size:14px; opacity:0.9;'>Experiencias Significativas</p>
                                </td>
                            </tr>
                            
                            <tr>
                                <td style='padding: 40px 40px 30px 40px;'>
                                    
                                    <h2 style='color:{darkText}; font-size:22px; margin-top:0; margin-bottom:15px;'>Hola {userName},</h2>
                                    
                                    <p style='font-size:16px; color:#4B5563; line-height:1.6;'>
                                        Nos complace compartir contigo el resultado oficial de tu más reciente evaluación.
                                    </p>

                                    <div style='margin:30px auto; max-width:80%; background:{color}; color:white; padding:20px; border-radius:12px; font-size:24px; font-weight:bold; box-shadow:0 2px 8px rgba(0,0,0,0.2);'>
                                        {evaluationResult}
                                    </div>

                                    <p style='font-size:16px; color:#4B5563; line-height:1.6; margin-top:30px;'>
                                        {message.Replace("**", "<strong>").Replace("</strong>", "</strong>")}
                                    </p>

                                   

                                    <hr style='border:none; height:1px; background-color:#E5E7EB; margin:40px 0;'>

                                    <p style='font-size:13px; color:#777;'>
                                        Este mensaje ha sido generado automáticamente por el Sistema de Evaluación.
                                        No respondas a este correo.
                                    </p>
                                </td>
                            </tr>
                            
                            <tr>
                                <td style='padding: 15px 40px; background-color:#E5E7EB; border-radius: 0 0 12px 12px; text-align:center;'>
                                    <p style='font-size:12px; color:#6B7280; margin:0;'>
                                        &copy; 2025 Sistema de Evaluación de Experiencias Significativas
                                    </p>
                                </td>
                            </tr>
                            
                        </table>
                    </td>
                </tr>
            </table>
        </div>";

        var body = new
        {
            sender = new { email = _fromEmail, name = _fromName },
            to = new[] { new { email = toEmail, name = userName } },
            subject = $"Resultado de tu Evaluación — {evaluationResult}",
            htmlContent = html
        };

        var content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
        var response = await _client.PostAsync("smtp/email", content);

        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsStringAsync();
            throw new Exception($"Error enviando correo Brevo: {error}");
        }
    }
}



