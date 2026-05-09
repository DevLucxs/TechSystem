using System.Net.Http.Json;
using cadastro.Shared.Models; // IMPORTANTE: Aponta para o Shared

namespace cadastro.Client.Services
{
    public class NotificacaoService
    {
        private readonly HttpClient _http;
        public List<Notificacao> Lista { get; private set; } = new();
        public event Action OnChange;

        public NotificacaoService(HttpClient http) => _http = http;

        public async Task CarregarNotificacoes()
        {
            try
            {
                // Ele busca do Controller e transforma na classe do Shared
                var dados = await _http.GetFromJsonAsync<List<Notificacao>>("api/notificacoes");
                if (dados != null)
                {
                    Lista = dados;
                    NotifyStateChanged();
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public void Adicionar(string titulo, string mensagem, string tipo)
        {
            Lista.Insert(0, new Notificacao { Titulo = titulo, Mensagem = mensagem, Tipo = tipo, CriadoEm = DateTime.Now });
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}