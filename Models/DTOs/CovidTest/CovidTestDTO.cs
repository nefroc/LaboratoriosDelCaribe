using System;
namespace Models.DTOs.CovidTest
{
    public class CovidTestDTO
    {
        public int id { get; set; }
        public int idCliente { get; set; }
        public int idCatalogoTest { get; set; }
        public string resultado { get; set; }
        public string numeroAutorizacion { get; set; }
        public string rdrp { get; set; }
        public int usuario { get; set; }
    }
}
