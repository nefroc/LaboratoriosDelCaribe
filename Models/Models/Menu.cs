using System;
namespace DataBaseContext.Models
{
    public class Menu
    {
        public int Id { get; set; }
        public int? PadreId { get; set; }
        public string Nombre { get; set; }
        public string Url { get; set; }
        public string IconClass { get; set; }
        public int CreadoPor { get; set; }
        public DateTime Creado { get; set; }
        public int? ModificadoPor { get; set; }
        public DateTime? Modificado { get; set; }

        public virtual Usuario CreadoPorNavigation { get; set; }
        public virtual Usuario ModificadoPorNavigation { get; set; }
    }
}
