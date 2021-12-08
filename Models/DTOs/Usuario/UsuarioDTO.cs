using System;
namespace Models.DTOs.Usuario
{
    public class UsuarioDTO
    {
        public int? id { get; set; }
        public string correo { get; set; }
        public string contrasena { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public bool activo { get; set; }
        public int creadoPor { get; set; }
        public int? idPerfil { get; set; }
    }
}
