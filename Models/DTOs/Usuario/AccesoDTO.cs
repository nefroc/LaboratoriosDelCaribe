using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.DTOs.Usuario
{
    public class AccesoDTO
    {
        [Required(ErrorMessage = "Nombre de usuario requerido.")]
        [Display(Name = "Usuario", Prompt = "Usuario")]
        public string Username { get; set; }

        [Required(ErrorMessage = "La contraseña no puede ser vacia.")]
        [Display(Name = "Contraseña", Prompt = "Contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}