using cadastro.Client;
using cadastro.Shared.Models;
using cadastro.Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped<IaService>();
builder.Services.AddSingleton<IdiomaService>();
builder.Services.AddSingleton<SessaoService>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IaServiceClient>();
builder.Services.AddScoped<NotificacaoService>();
builder.Services.AddScoped<NotificacaoState>();


// ✅ Configure o HttpClient para sua API
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:7002")
});


await builder.Build().RunAsync();