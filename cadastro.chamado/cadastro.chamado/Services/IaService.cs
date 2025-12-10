using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;
using cadastro.chamado.Services;

namespace cadastro.chamado.Services
{
    public class IaService
    {
        private readonly HttpClient _http;
        private readonly string _apiKey;

        public IaService(HttpClient http)
        {
            _http = http;
            _apiKey = Environment.GetEnvironmentVariable("GEMINI_API_KEY")
                ?? throw new Exception("GEMINI_API_KEY não encontrada no .env");
        }

        public async Task<string> GerarSugestao(string titulo, string descricao)
        {
            // CORREÇÃO AQUI: Mudando 'gemini-pro' para 'gemini-2.5-flash'
            var url =
            $"https://generativelanguage.googleapis.com/v1beta/models/gemini-2.5-flash:generateContent?key={_apiKey}";

            var requestBody = new
            {
                contents = new[]
                {
                    new
                    {
                        parts = new[]
                        {
                            new
                            {
                                text = $"Você é um analista técnico de help desk. Baseado no Título e Descrição, gere uma sugestão de resolução (máximo de 30 palavras). Formato: [Ação junto com algumas causas, e caso o problema persistir, sugerir abrir o chamado no botao abaixo].\nTítulo: {titulo}\nDescrição: {descricao}"
                            }
                        }
                    }
                }
            };

            var json = JsonSerializer.Serialize(requestBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _http.PostAsync(url, content);

            if (!response.IsSuccessStatusCode)
            {
                var erro = await response.Content.ReadAsStringAsync();
                return $"Erro Gemini: {erro}";
            }

            var result = await response.Content.ReadFromJsonAsync<JsonElement>();

            var text = result
                .GetProperty("candidates")[0]
                .GetProperty("content")
                .GetProperty("parts")[0]
                .GetProperty("text")
                .GetString();

            return text!;
        }

    }

}