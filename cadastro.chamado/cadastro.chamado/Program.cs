using cadastro.chamado.database;
using cadastro.chamado.Services;
using cadastro.Shared;
using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace cadastro.chamado
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var basePath = AppContext.BaseDirectory;

            while (!File.Exists(Path.Combine(basePath, ".env")))
            {
                basePath = Directory.GetParent(basePath)?.FullName
                    ?? throw new Exception("❌ Arquivo .env não encontrado na árvore de diretórios.");
            }

            Env.Load(Path.Combine(basePath, ".env"));

            var testKey = Environment.GetEnvironmentVariable("GEMINI_API_KEY");
            Console.WriteLine($"✅ TESTE OPENAI KEY: {testKey}");

            var builder = WebApplication.CreateBuilder(args);
            var apiKey = Environment.GetEnvironmentVariable("GEMINI_API_KEY");

            // Serviços
            builder.Services.AddRazorPages();
            builder.Services.AddControllers();

            // DbContext

            // 1. Pegue a string de conexão da variável de ambiente definida no seu .env
            var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");

            // 2. Verifique se ela foi carregada (ajuda no debug)
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new Exception("❌ A string de conexão 'DB_CONNECTION_STRING' não foi encontrada no arquivo .env.");
            }

            // 3. Configure o DbContext usando a variável
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));

            // IaService
            builder.Services.AddHttpClient<IaService>();
            builder.Services.AddScoped<IaService>();

            // Swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TechSystem API", Version = "v1" });

                // ✅ Evita conflito de classes com mesmo nome
                c.CustomSchemaIds(type => type.FullName);
            });


            // 👉 Configuração de CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowBlazorClient",
                    policy =>
                    {
                        policy.AllowAnyOrigin()
                              .AllowAnyHeader()
                              .AllowAnyMethod();
                    });
            });

            var app = builder.Build();

            // Pipeline
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "TechSystem API v1");
                });
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            // 👉 Ativa CORS antes dos endpoints
            app.UseCors("AllowBlazorClient");

            app.UseAuthorization();

            app.UseStaticFiles();

            app.MapRazorPages();
            app.MapControllers();
            app.MapFallbackToFile("index.html");

            app.Run();
        }
    }
}
