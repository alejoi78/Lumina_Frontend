using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BlazorWeb.Entidades
{
    public class Serie
    {
        public int IdSerie { get; set; }

        [Required(ErrorMessage = "El título es obligatorio")]
        public string Titulo { get; set; } = string.Empty;

    
        public string Director { get; set; } = string.Empty;

        [Range(1900, 2100, ErrorMessage = "El año debe estar entre 1900 y 2100")]
        public int Anio { get; set; }

      
        public string Link { get; set; } = string.Empty;

        public int Temporadas { get; set; }

 
        public string Genero { get; set; } = string.Empty;

        [Range(1, 5, ErrorMessage = "La calificación debe estar entre 1 y 5")]
        public string Calificacion { get; set; } = string.Empty;
    }
}