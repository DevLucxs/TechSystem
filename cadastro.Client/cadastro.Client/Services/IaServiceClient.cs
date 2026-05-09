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
            try
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
                    return result?.Sugestao ?? "IA: Não foi possível gerar uma sugestão agora.";
                }

                // Tratamento amigável para instabilidades do Gemini (Erro 503 ou 429)
                if (response.StatusCode == System.Net.HttpStatusCode.ServiceUnavailable)
                {
                    return "A IA está com alta demanda no momento. Tente novamente em instantes!";
                }

                var erro = await response.Content.ReadAsStringAsync();
                return "IA: No momento não consegui analisar seu chamado.";
            }
            catch (Exception ex)
            {
                // Log interno para você debugar, mas mensagem amigável para o usuário
                Console.WriteLine($"Erro de conexão com a API: {ex.Message}");
                return "IA: Verifique sua conexão com o servidor.";
            }
        }
    }
}