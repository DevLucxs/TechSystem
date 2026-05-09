using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace cadastro.Shared.Models
{
    [Table("Relatorios")] // Força o EF a usar o nome exato da imagem
    public class Relatorio
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Mensagem { get; set; } = string.Empty;

        [Column("Data")]
        public DateTime CriadoEm { get; set; } = DateTime.Now;
    }
}