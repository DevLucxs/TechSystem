namespace cadastro.Client.Services
{
    public class SessaoService
    {
        public int IdUsuario { get; set; }   // 🔑 novo campo
        public string NomeUsuario { get; set; } = "";
        public string Role { get; set; } = "";

        // Método auxiliar para definir a sessão
        public void DefinirSessao(int id, string nome, string role)
        {
            IdUsuario = id;
            NomeUsuario = nome;
            Role = role;
        }

        // Método para limpar sessão (logout)
        public void LimparSessao()
        {
            IdUsuario = 0;
            NomeUsuario = "";
            Role = "";
        }
    }
}
