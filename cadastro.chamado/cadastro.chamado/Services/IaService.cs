using System.Net.Http.Headers;
using System.Text.Json;

public class IaService
{
    private readonly HttpClient _http;
    private readonly string _apiKey;

    public IaService(HttpClient http, IConfiguration config)
    {
        _http = http;
        _apiKey = config["DeepSeek:ApiKey"]; // pega do appsettings.json
    }

    public async Task<string> GerarSugestao(string titulo, string descricao)
    {
        var requestBody = new
        {
            model = "deepseek-chat", // ou o modelo que você configurou
            messages = new[]
            {
                new { role = "system", content = "Você é um assistente que gera sugestões para chamados." },
                new { role = "user", content = $"Título: {titulo}\nDescrição: {descricao}" }
            }
        };

        _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);

        var response = await _http.PostAsJsonAsync("https://api.deepseek.com/v1/chat/completions", requestBody);

        if (!response.IsSuccessStatusCode)
        {
            var erro = await response.Content.ReadAsStringAsync();
            return $"Erro da API: {erro}";
        }

        var json = await response.Content.ReadFromJsonAsync<JsonElement>();
        return json.GetProperty("choices")[0].GetProperty("message").GetProperty("content").GetString();
    }


}
