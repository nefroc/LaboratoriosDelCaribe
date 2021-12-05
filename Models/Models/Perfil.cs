using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DataBaseContext.Models
{
    public class Perfil
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }
        public DateTime Creado { get; set; }
        public int CreadoPor { get; set; }
        public DateTime? Modificado { get; set; }
        public int? ModificadoPor { get; set; }

        public virtual Usuario CreadoPorNavigation { get; set; }
        public virtual Usuario ModificadoPorNavigation { get; set; }

        [JsonIgnore]
        public virtual ICollection<Usuario> UsuarioNavigation { get; set; }
    }
}
