using System.ComponentModel.DataAnnotations;

namespace BlazorWeb.Entidades
{
    public class Login
    {
        public int IdUsuario { get; set; }
        public string Correo { get; set; }

        [Required(ErrorMessage = "El usuario es obligatorio")]
        [StringLength(100, ErrorMessage = "El usuario no debe superar los 100 caracteres")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "La contraseña debe tener al menos 6 caracteres")]
        public string Contrasena { get; set; } = string.Empty;
        public string? Mensaje { get; set; }
        public string? Token { get; set; }
    }
}
