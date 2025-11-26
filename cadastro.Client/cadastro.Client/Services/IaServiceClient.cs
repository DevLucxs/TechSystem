using System.Net.Http.Json;
using cadastro.Shared;

namespace cadastro.Client.Services
{
    public class IaServiceClient
    {
        private readonly HttpClient _http;

        public IaServiceClient(HttpClient http)
        {
            _http = http;
        }

        public async Task<string> GerarSugestao(string titulo, string descricao)
        {
            var request = new SugestaoRequest
            {
                Titulo = titulo,
                Descricao = descricao
            };

            var response = await _http.PostAsJsonAsync("api/chamado/sugestao", request);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<SugestaoResponse>();
                return result?.Sugestao ?? "Não foi possível gerar sugestão.";
            }
            else
            {
                var erro = await response.Content.ReadAsStringAsync();
                return $"Erro da API: {erro}";
            }
        }
    }

    public class SugestaoResponse
    {
        public string Sugestao { get; set; } = string.Empty;
    }
}
