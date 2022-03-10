using System;
using System.Collections.Generic;

namespace DataBaseContext.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Sexo { get; set; }
        public string Telefono { get; set; }
        public string NombreDoctor { get; set; }
        public string Email { get; set; }
        public string NumeroPasaporte { get; set; }
        public int CreadoPor { get; set; }
        public DateTime Creado { get; set; }
        public int? ModificadoPor { get; set; }
        public DateTime? Modificado { get; set; }

        public virtual Usuario CreadoPorNavigation { get; set; }
        public virtual Usuario ModificadoPorNavigation { get; set; }

        public virtual ICollection<COVIDTest> COVIDTestNavigation { get; set; }
    }
}
