namespace BlazorWeb.Entidades
{
    public class Episodio
    {
        public int IdEpisodio { get; set; }
        public string Nombre { get; set; }
        public string Temporada { get; set; }
        public string Link { get; set; }
        public int? DuracionMin { get; set; }
        public int IdSerie { get; set; } // Clave foránea
        public string NombreArchivoVideo { get; set; }
    }
}