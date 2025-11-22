using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class SupabaseStorageService
{
    public async Task<string> UploadEvaluationPdfToSupabase(byte[] pdfBytes, int evaluationId)
    {
        string fileName = $"Reporte-{evaluationId}.pdf";
        string supabaseUrl = "https://clzjdaburaytuimossnf.supabase.co";
        string supabaseKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImNsempkYWJ1cmF5dHVpbW9zc25mIiwicm9sZSI6InNlcnZpY2Vfcm9sZSIsImlhdCI6MTc2MTMyMjQ2MywiZXhwIjoyMDc2ODk4NDYzfQ.V2LsB80vdb3ymThtQBoyLrw6p6Nsx7w7n3DX39V2bPY";
        string bucket = "Experiencia-SignificativaPdf";

        using var client = new HttpClient();
        client.BaseAddress = new Uri(supabaseUrl);
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", supabaseKey);
        client.DefaultRequestHeaders.Add("apikey", supabaseKey);

        string uploadUrl = $"/storage/v1/object/{bucket}/{fileName}";
        var content = new ByteArrayContent(pdfBytes);
        content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");

        var uploadResponse = await client.PutAsync(uploadUrl, content);
        if (!uploadResponse.IsSuccessStatusCode)
        {
            var error = await uploadResponse.Content.ReadAsStringAsync();
            throw new Exception($"❌ Error subiendo PDF a Supabase: {error}");
        }

        // Generar firmada válida por 1 año
        string signUrl = $"/storage/v1/object/sign/{bucket}/{fileName}";
        var signBody = new { expiresIn = 31536000 }; 
        var signContent = new StringContent(JsonConvert.SerializeObject(signBody), Encoding.UTF8, "application/json");

        var signResponse = await client.PostAsync(signUrl, signContent);
        if (!signResponse.IsSuccessStatusCode)
        {
            var error = await signResponse.Content.ReadAsStringAsync();
            throw new Exception($"❌ Error generando URL firmada: {error}");
        }

        var json = await signResponse.Content.ReadAsStringAsync();
        dynamic result = JsonConvert.DeserializeObject(json);

        // Armar la firmada correctamente
        return $"{supabaseUrl}/storage/v1{result.signedURL}";
    }
}






