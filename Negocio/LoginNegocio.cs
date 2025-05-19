using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;  // Añade este using
using BlazorWeb.Entidades;

namespace BlazorWeb.Negocio
{
    public class LoginNegocio
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<LoginNegocio> _logger;
        private readonly IJSRuntime _jsRuntime;  // Añade esta inyección
        private readonly string _baseApiUrl = "http://localhost:5950/usuarios/autenticar";

        // Modifica el constructor para inyectar IJSRuntime
        public LoginNegocio(HttpClient httpClient, ILogger<LoginNegocio> logger, IJSRuntime jsRuntime)
        {
            _httpClient = httpClient;
            _logger = logger;
            _jsRuntime = jsRuntime;
        }

        public async Task<Login> Autenticar(string nombre, string contrasena)
{
    try
    {
        // Objeto con los valores fijos que requieres
        var requestData = new
        {
            idUsuario = 0,  // Valor fijo como solicitaste
            Correo = "correo@gmail.com",  // Valor fijo como solicitaste
            Nombre = nombre,
            Contrasena = contrasena
        };

        // Asegúrate que _baseApiUrl apunte al endpoint correcto
        // Ejemplo: "api/usuarios/autenticar" o "usuarios/autenticar"
        var response = await _httpClient.PostAsJsonAsync(_baseApiUrl, requestData);

        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            throw new ApplicationException($"Error en autenticación: {errorContent}");
        }

        return await response.Content.ReadFromJsonAsync<Login>();
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Error al autenticar");
        return new Login
        {
    
            Mensaje = ex.Message,
            Nombre = nombre
        };
    }
}

        public async Task<string?> ObtenerTokenAsync(string clave)
        {
            try
            {
                // Corregido: Usa IJSRuntime en lugar de HttpClient
                return await _jsRuntime.InvokeAsync<string>("localStorage.getItem", clave);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener el token con clave '{clave}'");
                return null;
            }
        }

        public async Task GuardarTokenAsync(string clave, string valor)
        {
            try
            {
                await _jsRuntime.InvokeVoidAsync("localStorage.setItem", clave, valor);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al guardar el token con clave '{clave}'");
            }
        }
    }
}