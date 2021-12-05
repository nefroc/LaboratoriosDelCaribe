using System;
namespace LabCaribeWeb.Utility
{
    public interface ISessionManager
    {
        int IdUsuario
        {
            get; set;
        }

        String Correo
        {
            get; set;
        }

        String Nombre
        {
            get; set;
        }

        String Apellidos
        {
            get; set;
        }

        int IdPerfil
        {
            get; set;
        }
    }
}
