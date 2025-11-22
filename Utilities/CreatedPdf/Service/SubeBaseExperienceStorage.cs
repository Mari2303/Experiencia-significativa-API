using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.CreatedPdf.Service
{
    public class SubeBaseExperienceStorage
    {
        public async Task<string> UploadExperiencePdfToSupabase(byte[] pdfBytes, int experienceId)
        {
            string fileName = $"Experiencia-{experienceId}.pdf";
            string supabaseUrl = "https://clzjdaburaytuimossnf.supabase.co";
            string supabaseKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImNsempkYWJ1cmF5dHVpbW9zc25mIiwicm9sZSI6InNlcnZpY2Vfcm9sZSIsImlhdCI6MTc2MTMyMjQ2MywiZXhwIjoyMDc2ODk4NDYzfQ.V2LsB80vdb3ymThtQBoyLrw6p6Nsx7w7n3DX39V2bPY";
            string bucket = "Experiencia-SignificativaPdf";

            using var client = new HttpClient();
            client.BaseAddress = new Uri(supabaseUrl);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", supabaseKey);
            client.DefaultRequestHeaders.Add("apikey", supabaseKey);

            // Se encarga de subir el archivo
            string uploadUrl = $"/storage/v1/object/{bucket}/{fileName}";
            var content = new ByteArrayContent(pdfBytes);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");

            var uploadResponse = await client.PutAsync(uploadUrl, content);
            if (!uploadResponse.IsSuccessStatusCode)
            {
                var error = await uploadResponse.Content.ReadAsStringAsync();
                throw new Exception($" Error subiendo PDF a Supabase: {error}");
            }

            // Genera la firma  por 1 año
            string signUrl = $"/storage/v1/object/sign/{bucket}/{fileName}";
            var body = new { expiresIn = 31536000 };
            var jsonBody = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");

            var signResponse = await client.PostAsync(signUrl, jsonBody);
            if (!signResponse.IsSuccessStatusCode)
            {
                var error = await signResponse.Content.ReadAsStringAsync();
                throw new Exception($" Error generando URL firmada: {error}");
            }

            dynamic json = JsonConvert.DeserializeObject(await signResponse.Content.ReadAsStringAsync());

            // limpiar para evitar errores de base64 y browsers
            string signedURL = ((string)json.signedURL).Replace("\\/", "/");

            return $"{supabaseUrl}/storage/v1{signedURL}";
        }


    }
}
