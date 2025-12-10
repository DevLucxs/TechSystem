namespace cadastro.Shared
{
    public class Chamado
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Status { get; set; }
        public string Prioridade { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? Previsao { get; set; }
        public string Responsavel { get; set; }
        public string SugestaoIA { get; set; }
    }

    public class SugestaoRequest
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
    }

    public class SugestaoResponse
    {
        public string Sugestao { get; set; } = string.Empty;
    }
}
