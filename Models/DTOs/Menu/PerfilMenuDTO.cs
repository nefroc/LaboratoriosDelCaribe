using System;
namespace Models.DTOs.Menu
{
    public class PerfilMenuDTO
    {
        public int idMenu { get; set; }
        public int? padreId { get; set; }
        public string nombre { get; set; }
        public string url { get; set; }
        public string iconClass { get; set; }
    }
}
