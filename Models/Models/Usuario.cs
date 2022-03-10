using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DataBaseContext.Models
{
    public class Usuario
    {
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

        public virtual Usuario CreadoPorNavigation { get; set; }

        public virtual Usuario ModificadoPorNavigation { get; set; }

        public virtual Perfil PerfilNavigation { get; set; }

        public virtual ICollection<Usuario> InverseCreadoPorNavigation { get; set; }
        public virtual ICollection<Usuario> InverseModificadoPorNavigation { get; set; }

        public virtual ICollection<Menu> MenuCreadoPorNavigation { get; set; }
        public virtual ICollection<Menu> MenuModificadoPorNavigation { get; set; }

        public virtual ICollection<Perfil> PerfilCreadoPorNavigation { get; set; }
        public virtual ICollection<Perfil> PerfilModificadoPorNavigation { get; set; }

        public virtual ICollection<PerfilMenu> PerfilMenuCreadoPorNavigation { get; set; }
        public virtual ICollection<PerfilMenu> PerfilMenuModificadoPorNavigation { get; set; }

        public virtual ICollection<Cliente> ClienteCreadoPorNavigation { get; set; }
        public virtual ICollection<Cliente> ClienteModificadoPorNavigation { get; set; }

        public virtual ICollection<CatalogoTest> CatalogoTestCreadoPorNavigation { get; set; }
        public virtual ICollection<CatalogoTest> CatalogoTestModificadoPorNavigation { get; set; }

        public virtual ICollection<COVIDTest> COVIDTestCreadoPorNavigation { get; set; }
        public virtual ICollection<COVIDTest> COVIDTestModificadoPorNavigation { get; set; }
    }
}
