using System.Collections.Generic;

namespace BlazorWeb.Entidades
{
    public class Serie
    {
        public int IdSerie { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Director { get; set; } = string.Empty;
        public int Anio { get; set; }
        public string Link { get; set; } = string.Empty;
        public int Temporadas { get; set; }
        public double DuracionPorCapitulo { get; set; }
        public string Genero { get; set; } = string.Empty;
        public double Calificacion { get; set; }
        public string Imagen { get; set; } = string.Empty;

        // Propiedad para los episodios
        public List<Episodio> Episodios { get; set; } = new List<Episodio>();
    }
}