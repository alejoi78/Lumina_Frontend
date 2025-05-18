using System.Net.Http;
using System;
using BlazorWeb;
using BlazorWeb.Negocio;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");  // Selector CSS válido
builder.RootComponents.Add<HeadOutlet>("head::after");  // Selector correcto


builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
});

//builder.Services.AddScoped<SerieNegocio>();
builder.Services.AddScoped<PeliculaNegocio>();
builder.Services.AddHttpClient();
await builder.Build().RunAsync();
