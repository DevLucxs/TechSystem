using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using cadastro.chamado.database;
namespace cadastro.chamado.database
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=TechSystemDb;Trusted_Connection=True;TrustServerCertificate=True;");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
