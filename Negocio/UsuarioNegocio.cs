using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using BlazorWeb.Entidades;

namespace BlazorWeb.Negocio
{
    public class UsuarioNegocio
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<UsuarioNegocio> _logger;
        private readonly string _baseApiUrl = "http://localhost:5950/usuarios";

        public UsuarioNegocio(HttpClient httpClient, ILogger<UsuarioNegocio> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<List<Usuario>> listarUsuarios()
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseApiUrl}/listar");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<List<Usuario>>() ?? new List<Usuario>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al listar usuarios");
                return new List<Usuario>();
            }
        }

        public async Task<bool> guardarUsuarios(Usuario usuario)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"{_baseApiUrl}/registrar", usuario);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al guardar usuario");
                return false;
            }
        }

        public async Task<bool> actualizarUsuarios(Usuario usuario)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"{_baseApiUrl}/actualizar", usuario);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al actualizar usuario ID: {usuario.IdUsuario}");
                return false;
            }
        }

        public async Task<bool> eliminarUsuario(int idUsuario)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{_baseApiUrl}/eliminar?id={idUsuario}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al eliminar usuario ID: {idUsuario}");
                return false;
            }
        }
    }
}