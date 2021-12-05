using System;
using System.Collections.Generic;
using System.Linq;
using DataBaseContext;
using DataBaseContext.Models;
using Models.DTOs.Usuario;
using Services.Interfaces;

namespace Services.Services
{
    public class UsuarioService: IUsuarioService
    {
        private readonly LabDBContext _labDBContext;

        public UsuarioService(LabDBContext labDBContext)
        {
            _labDBContext = labDBContext;
        }

        public bool Add(Usuario usuario) {
            bool resultado = false;
            try
            {
                var usuarioExiste = _labDBContext.Usuario.Where(user => user.Correo == usuario.Correo).FirstOrDefault();
                if (usuarioExiste == null) {
                    _labDBContext.Usuario.Add(usuario);
                    _labDBContext.SaveChanges();

                    resultado = true;
                }
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }

            return resultado;
        }

        public List<Usuario> GetAll() {
            return _labDBContext.Usuario.ToList();
        }

        public UsuarioLogueadoDTO Autenticacion(AccesoDTO login) {

            UsuarioLogueadoDTO usuarioLogueado = new UsuarioLogueadoDTO();
            try
            {
                var usuarioExiste = _labDBContext.Usuario.Where(user => user.Correo == login.Username).FirstOrDefault();
                if (usuarioExiste != null)
                {
                    if (usuarioExiste.Contrasena == login.Password)
                    {
                        usuarioLogueado.IdUsuario = usuarioExiste.Id;
                        usuarioLogueado.Nombre = usuarioExiste.Nombre;
                        usuarioLogueado.Apellidos = usuarioExiste.Apellidos;
                        usuarioLogueado.Correo = usuarioExiste.Correo;
                        usuarioLogueado.IdPerfil = usuarioExiste.IdPerfil;
                        usuarioLogueado.Mensaje = null;
                    }
                    else {
                        usuarioLogueado.Mensaje = "Password incorrecto.";
                    }
                }
                else {
                    usuarioLogueado.Mensaje = "El usuario no existe.";
                }
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }

            return usuarioLogueado;
        }
    }
}
