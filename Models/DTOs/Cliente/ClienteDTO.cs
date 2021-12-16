using System;
namespace Models.DTOs.Cliente
{
    public class ClienteDTO
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int edad { get; set; }
        public DateTime? fechaNacimiento { get; set; }
        public string sexo { get; set; }
        public string telefono { get; set; }
        public string nombreDoctor { get; set; }
        public string email { get; set; }
        public string numeroPasaporte { get; set; }
        public int usuario { get; set; }
    }
}
