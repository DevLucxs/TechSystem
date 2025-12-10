using cadastro.chamado.database;
using cadastro.chamado.Services;
using cadastro.Shared;
using DotNetEnv;
using Google.Apis.Aiplatform.v1;
using Google.Apis.Services;
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

            var testKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY");
            Console.WriteLine($"✅ TESTE OPENAI KEY: {testKey}");

            var builder = WebApplication.CreateBuilder(args);
            var apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY");

            // Serviços
            builder.Services.AddRazorPages();
            builder.Services.AddControllers();

            // DbContext
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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
