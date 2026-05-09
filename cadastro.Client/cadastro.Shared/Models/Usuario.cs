using System.ComponentModel.DataAnnotations;
namespace cadastro.Shared.Models

{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O Email informado não é válido.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo Senha é obrigatório.")]
        [MinLength(6, ErrorMessage = "A senha deve ter pelo menos 6 caracteres.")]
        public string SenhaHash { get; set; } = string.Empty;
        public string Role { get; set; } = "Usuario"; // Admin ou Usuario


    }

    public class LoginRequest
    {
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
    }

    public class LoginResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; } = "";
        public string Email { get; set; } = "";
        public string Role { get; set; } = "";
    }

}