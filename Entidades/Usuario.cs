﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BlazorWeb.Entidades
{
    public class Usuario
    {

        public int IdUsuario { get; set; }

        public string Nombre { get; set; }

        
        public string Correo { get; set; }

        public string Contrasena { get; set; }

        public int IdRol { get; set; } = 2;
    }
}
