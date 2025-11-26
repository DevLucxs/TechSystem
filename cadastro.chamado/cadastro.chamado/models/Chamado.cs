namespace cadastro.chamado.models
{
    public class Chamado
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




    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string SenhaHash { get; set; } = string.Empty;
        public string Role { get; set; } = "Usuario"; // "Admin" ou "Usuario"
    }

    public class LoginRequest
    {
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
    }

    public class RelatorioDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; } = DateTime.Now;
    }

    public class NotificacaoDto
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string Icone { get; set; }
        public string Titulo { get; set; }
        public string Mensagem { get; set; }
        public string Tempo { get; set; }
        public DateTime CriadoEm { get; set; } = DateTime.Now;

    }

}
