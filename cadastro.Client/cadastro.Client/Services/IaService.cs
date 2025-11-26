using System.Net.Http.Json;
using System.Text.Json;

public class IaService
{
    private readonly HttpClient _http;

    public IaService(HttpClient http)
    {
        _http = http;
    }

    public async Task<string> GerarSugestao(string titulo, string descricao)
    {
        var requestBody = new { Titulo = titulo, Descricao = descricao };

        var response = await _http.PostAsJsonAsync("https://localhost:7002/api/chamado/sugestao", requestBody);

        if (!response.IsSuccessStatusCode)
            return $"Erro da API: {response.StatusCode}";

        var json = await response.Content.ReadFromJsonAsync<JsonElement>();
        return json.GetProperty("sugestao").GetString();
    }
}