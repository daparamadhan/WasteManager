using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace WasteManagementSystem.Services
{
    public class ChatService
    {
        private readonly string _apiKey;
        private readonly string _url = "https://api.groq.com/openai/v1/chat/completions";
        private static readonly HttpClient _client = new HttpClient();

        public ChatService()
        {
            var config = new Microsoft.Extensions.Configuration.ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            _apiKey = config["Groq:ApiKey"] ?? "";
        }

        public async Task<string> GetResponseAsync(string userPrompt)
        {
            try
            {
                _client.DefaultRequestHeaders.Clear();
                _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");

                var requestBody = new
                {
                    model = "llama-3.3-70b-versatile",
                    messages = new[] {
                        new { role = "system", content = "Anda adalah pakar manajemen sampah Jawa Barat. Jawablah pertanyaan user secara langsung, singkat, padat, dan hanya sesuai dengan apa yang ditanyakan saja tanpa basa-basi atau informasi tambahan yang tidak diminta. Gunakan Bahasa Indonesia." },
                        new { role = "user", content = userPrompt }
                    },
                    temperature = 0.7
                };

                var json = JsonSerializer.Serialize(requestBody);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _client.PostAsync(_url, content);
                var responseString = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return $"API Error: {response.StatusCode}. {responseString}";
                }

                using var doc = JsonDocument.Parse(responseString);
                return doc.RootElement
                    .GetProperty("choices")[0]
                    .GetProperty("message")
                    .GetProperty("content")
                    .GetString() ?? "Maaf, AI tidak memberikan respon.";
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }
    }
}
