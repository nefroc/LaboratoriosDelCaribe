using System;
namespace Models.DTOs.Usuario
{
    public class UsuarioLogueadoDTO
    {
        public int? IdUsuario { get; set; }
        public string Correo { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Mensaje { get; set; }
        public int? IdPerfil { get; set; }
    }
}
