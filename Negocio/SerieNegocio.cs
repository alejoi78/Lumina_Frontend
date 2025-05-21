using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using BlazorWeb.Entidades;

namespace BlazorWeb.Negocio
{
    public class SerieNegocio
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<SerieNegocio> _logger;
        private readonly string _baseApiUrl = "http://localhost:5950/series";

        public SerieNegocio(HttpClient httpClient, ILogger<SerieNegocio> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<List<Serie>> listarSeries()
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseApiUrl}/listar");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<List<Serie>>() ?? new List<Serie>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al listar series");
                return new List<Serie>();
            }
        }

        public async Task<bool> guardarSerie(Serie serie)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"{_baseApiUrl}/nuevo", serie);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al guardar serie");
                return false;
            }
        }

        public async Task<bool> actualizarSeries(Serie serie)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"{_baseApiUrl}/actualizar", serie);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al actualizar la serie ID: {serie.IdSerie}");
                return false;
            }
        }

        public async Task<bool> eliminarSerie(int idSerie)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{_baseApiUrl}/eliminar?id={idSerie}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al eliminar serie con ID: {idSerie}");
                return false;
            }
        }
    }
}