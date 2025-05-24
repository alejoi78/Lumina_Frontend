using BlazorWeb.Negocio;
using BlazorWeb;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Configuración del HttpClient (cambia a HTTPS)
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:5950") // Cambiado a HTTPS
});

// Configuración HttpClientFactory (recomendado)
builder.Services.AddHttpClient("BackendAPI", client =>
{
    client.BaseAddress = new Uri("https://localhost:5950"); // Cambiado a HTTPS
});

// Registro de servicios
builder.Services.AddScoped<SerieNegocio>();
builder.Services.AddScoped<PeliculaNegocio>();
builder.Services.AddScoped<LoginNegocio>();
builder.Services.AddScoped<UsuarioNegocio>();

await builder.Build().RunAsync();