using System;
namespace Models.DTOs.Usuario
{
    public class ListaUsuariosDTO
    {
        public int id { get; set; }
        public string correo { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public bool activo { get; set; }
        public string perfil { get; set; }
    }
}
