using System;
namespace DataBaseContext.Models
{
    public class PerfilMenu
    {
        public int Id { get; set; }
        public int IdPerfil { get; set; }
        public int IdMenu { get; set; }
        public int CreadoPor { get; set; }
        public DateTime Creado { get; set; }
        public int? ModificadoPor { get; set; }
        public DateTime? Modificado { get; set; }

        public virtual Usuario CreadoPorNavigation { get; set; }
        public virtual Usuario ModificadoPorNavigation { get; set; }
    }
}
