namespace cadastro.Client.Models
{
    public class Notificacao
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string Icone { get; set; }
        public string Titulo { get; set; }
        public string Mensagem { get; set; }
        public string Tempo { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}
