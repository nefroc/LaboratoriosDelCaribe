using System;
namespace DataBaseContext.Models
{
    public class COVIDTest
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int IdCatalogoTest { get; set; }
        public string Resultado { get; set; }
        public string NumeroAutorizacion { get; set; }
        public string RdRP { get; set; }
        public int CreadoPor { get; set; }
        public DateTime Creado { get; set; }
        public int? ModificadoPor { get; set; }
        public DateTime? Modificado { get; set; }

        public virtual Cliente ClienteNavigation { get; set; }
        public virtual CatalogoTest CatalogoTestNavigation { get; set; }
        public virtual Usuario CreadoPorNavigation { get; set; }
        public virtual Usuario ModificadoPorNavigation { get; set; }
    }
}
