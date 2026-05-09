using System;
using System.ComponentModel.DataAnnotations;

namespace cadastro.Shared.Models
{
    public class Chamado
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O título é obrigatório")]
        public string Titulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "A descrição é obrigatória")]
        public string Descricao { get; set; } = string.Empty;

        public string? Status { get; set; } = "Aberto";
        public string? Prioridade { get; set; }
        public string? Responsavel { get; set; }
        public string? SugestaoIA { get; set; }

        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public DateTime? Previsao { get; set; }

        // Este campo é essencial para as notificações funcionarem!
        public int UsuarioId { get; set; }
    }
}