using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DataBaseContext.Models
{
    public class Usuario
    {
        public Usuario()
        {
        }

        public int Id { get; set; }
        public string Correo { get; set; }
        public string Contrasena { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public bool Activo { get; set; }
        public int? IdPerfil { get; set; }
        public int CreadoPor { get; set; }
        public DateTime Creado { get; set; }
        public int? ModificadoPor { get; set; }
        public DateTime? Modificado { get; set; }

        [JsonIgnore]
        public virtual Usuario CreadoPorNavigation { get; set; }
        [JsonIgnore]
        public virtual Usuario ModificadoPorNavigation { get; set; }
        public virtual Perfil PerfilNavigation { get; set; }

        [JsonIgnore]
        public virtual ICollection<Usuario> InverseCreadoPorNavigation { get; set; }
        [JsonIgnore]
        public virtual ICollection<Usuario> InverseModificadoPorNavigation { get; set; }

        [JsonIgnore]
        public virtual ICollection<Menu> MenuCreadoPorNavigation { get; set; }
        [JsonIgnore]
        public virtual ICollection<Menu> MenuModificadoPorNavigation { get; set; }

        [JsonIgnore]
        public virtual ICollection<Perfil> PerfilCreadoPorNavigation { get; set; }
        [JsonIgnore]
        public virtual ICollection<Perfil> PerfilModificadoPorNavigation { get; set; }

        [JsonIgnore]
        public virtual ICollection<PerfilMenu> PerfilMenuCreadoPorNavigation { get; set; }
        [JsonIgnore]
        public virtual ICollection<PerfilMenu> PerfilMenuModificadoPorNavigation { get; set; }
    }
}
