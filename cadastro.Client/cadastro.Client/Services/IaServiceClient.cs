using System.Net.Http.Json;
using cadastro.Shared; // Contém SugestaoRequest e SugestaoResponse

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
            // O Cliente HTTP não precisa da chave de IA, pois ele só chama sua API.
            var request = new SugestaoRequest
            {
                Titulo = titulo,
                Descricao = descricao
            };

            // Chamada HTTP para o endpoint da sua própria API
            var response = await _http.PostAsJsonAsync("api/chamado/sugestao", request);

            if (response.IsSuccessStatusCode)
            {
                // Note: O retorno do Controller da API é um objeto { sugestao: "..." }
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
}