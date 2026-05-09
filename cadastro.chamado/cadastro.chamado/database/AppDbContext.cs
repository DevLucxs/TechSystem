using cadastro.Shared.Models;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;

namespace cadastro.chamado.database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Chamado> Chamados { get; set; }
        public DbSet<cadastro.Shared.Models.Usuario> Usuarios { get; set; }// ← ESSENCIAL!
        public DbSet<Relatorio> Relatorios { get; set; }
        public DbSet<Notificacao> Notificacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    Id = 1,
                    Nome = "Administrador",
                    Email = "admin@techsystem.com",
                    SenhaHash = BCrypt.Net.BCrypt.HashPassword("admin123"),
                    Role = "Admin"
                },
                new Usuario
                {
                    Id = 2,
                    Nome = "Usuário Comum",
                    Email = "usuario@techsystem.com",
                    SenhaHash = BCrypt.Net.BCrypt.HashPassword("usuario123"),
                    Role = "Usuario"
                }

            );

        }
    }
}
