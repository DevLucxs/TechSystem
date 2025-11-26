using cadastro.Client;
using cadastro.Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Net.NetworkInformation;
using static cadastro.Client.Pages.Configuracao;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped<IaService>();
builder.Services.AddSingleton<IdiomaService>();
builder.Services.AddSingleton<SessaoService>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IaServiceClient>();

// ✅ Configure o HttpClient para sua API
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:7002")
});


await builder.Build().RunAsync();
