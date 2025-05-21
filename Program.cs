using BlazorWeb.Negocio;
using BlazorWeb;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Configuración del HttpClient para apuntar a tu backend
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("http://localhost:5950") // Asegúrate que coincide con tu backend
});

// Si usas HttpClientFactory (recomendado para servicios)
builder.Services.AddHttpClient("BackendAPI", client =>
{
    client.BaseAddress = new Uri("http://localhost:5950");
});

// Registro de tus servicios
builder.Services.AddScoped<SerieNegocio>();
builder.Services.AddScoped<PeliculaNegocio>();
builder.Services.AddScoped<LoginNegocio>();
builder.Services.AddScoped<UsuarioNegocio>();

await builder.Build().RunAsync();