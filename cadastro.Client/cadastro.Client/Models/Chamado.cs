 
namespace cadastro.Client.Models
{
    public class ChamadoForm
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string Prioridade { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public DateTime DataCriacao { get; set; }
        public string Equipe { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string SugestaoIA { get; set; } = string.Empty;
        public DateTime? Previsao { get; set; }
        public string Responsavel { get; set; } = string.Empty;

        public int UsuarioId { get; set; }

    }


}
