using System;
using Microsoft.AspNetCore.Http;

namespace LabCaribeWeb.Utility
{
    public class SessionManager : ISessionManager
    {

        private readonly ISession _session;

        public SessionManager(IHttpContextAccessor httpContextAccessor)
        {
            _session = httpContextAccessor.HttpContext.Session;
        }

        public int IdUsuario
        {
            get {
                var v = _session.GetInt32("IdUsuario");
                if (v.HasValue)
                    return v.Value;
                else
                    return 0;
            }
            set {
                _session.SetInt32("IdUsuario", value);
            }
        }

        public String Correo
        {
            get
            {
                return _session.GetString("Correo");
            }
            set
            {
                _session.SetString("Correo", value);
            }
        }

        public String Nombre
        {
            get
            {
                return _session.GetString("Nombre");
            }
            set
            {
                _session.SetString("Nombre", value);
            }
        }

        public String Apellidos
        {
            get
            {
                return _session.GetString("Apellidos");
            }
            set
            {
                _session.SetString("Apellidos", value);
            }
        }

        public int IdPerfil
        {
            get
            {
                var v = _session.GetInt32("IdPerfil");
                if (v.HasValue)
                    return v.Value;
                else
                    return 0;
            }
            set
            {
                _session.SetInt32("IdPerfil", value);
            }
        }

        public String Token
        {
            get
            {
                return _session.GetString("Token");
            }
            set
            {
                _session.SetString("Token", value);
            }
        }
    }
}
