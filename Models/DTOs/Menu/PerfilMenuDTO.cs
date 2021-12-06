using System;
using System.Collections.Generic;

namespace Models.DTOs.Menu
{
    public class PerfilMenuDTO
    {
        public int idMenu { get; set; }
        public string nombre { get; set; }
        public string url { get; set; }
        public string iconClass { get; set; }
        public IList<PerfilMenuDTO> children { get; set; }
    }
}
