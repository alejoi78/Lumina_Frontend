using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using BlazorWeb.Entidades;

namespace BlazorWeb.Negocio
{
    public class PeliculaNegocio
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<PeliculaNegocio> _logger;
        private readonly string _baseApiUrl = "http://localhost:5950/peliculas";

        public PeliculaNegocio(HttpClient httpClient, ILogger<PeliculaNegocio> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }


        public async Task<List<Pelicula>> listarPeliculas()
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseApiUrl}/listar");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<List<Pelicula>>() ?? new List<Pelicula>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al listar películas");
                return new List<Pelicula>();
            }
        }

        public async Task<Pelicula> obtenerPorId(int idPelicula)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseApiUrl}/obtenerPorId?id={idPelicula}");

                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogError($"Error al obtener película. Código de estado: {response.StatusCode}");
                    return null;
                }

                return await response.Content.ReadFromJsonAsync<Pelicula>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener película con ID: {idPelicula}");
                return null;
            }
        }


        public async Task<bool> guardarPelicula(Pelicula pelicula)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"{_baseApiUrl}/nuevo", pelicula);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al guardar película");
                return false;
            }
        }

        public async Task<bool> actualizarPeliculas(Pelicula pelicula)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"{_baseApiUrl}/actualizar", pelicula);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al actualizar película ID: {pelicula.IdPelicula}");
                return false;
            }
        }

        public async Task<bool> eliminarPelicula(int idPelicula)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{_baseApiUrl}/eliminar?id={idPelicula}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al eliminar pelicula con ID: {idPelicula}");
                return false;
            }
        }
    }
}