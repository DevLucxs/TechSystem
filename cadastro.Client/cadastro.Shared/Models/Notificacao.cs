namespace cadastro.Shared.Models
{
    public class Notificacao
    {
        public int Id { get; set; }
        public int? UsuarioId { get; set; }

        // Inicializar com string.Empty evita o erro 400 por falta de valor
        public string Tipo { get; set; } = "admin";
        public string Icone { get; set; } = "🚀";
        public string Titulo { get; set; } = string.Empty;
        public string Mensagem { get; set; } = string.Empty;
        public string Tempo { get; set; } = string.Empty;

        public bool Lida { get; set; } = false;
        public DateTime CriadoEm { get; set; } = DateTime.Now;
    }
}