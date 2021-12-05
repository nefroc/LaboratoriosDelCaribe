using System.ComponentModel.DataAnnotations;

namespace LabCaribeWeb.Models
{
    public class Login
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
