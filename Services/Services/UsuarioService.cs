using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using DataBaseContext;
using DataBaseContext.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Models.DTOs.Usuario;
using Services.Interfaces;
using Tools;
using Dapper;
using MySqlConnector;

namespace Services.Services
{
    public class UsuarioService: IUsuarioService
    {
        private readonly LabDBContext _labDBContext;
        private readonly AppSettings _appSettings;
        private readonly IDbConnection _db;

        public UsuarioService(LabDBContext labDBContext, IOptions<AppSettings> appSettings)
        {
            _labDBContext = labDBContext;
            _appSettings = appSettings.Value;
            _db = new MySqlConnection(Global.ConnectionString);
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

        public List<ListaUsuariosDTO> GetListaUsuarios() {
            List<ListaUsuariosDTO> listaUsuarios = null;
            try
            {
                using (var conn = _db)
                {
                    listaUsuarios = conn.Query<ListaUsuariosDTO>("select U.id, U.correo, U.nombre, U.apellidos, U.activo, P.nombre as perfil " +
                                                                 "from LabDelCaribe.Usuario as U " +
                                                                 "left join LabDelCaribe.Perfil as P on U.idPerfil = P.id " +
                                                                 "order by U.nombre, U.apellidos").ToList();
                }
            }
            catch (Exception ex)
            {
                listaUsuarios = null;
            }

            return listaUsuarios;
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
                        usuarioLogueado.Token = GetToken(usuarioLogueado);
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

        private string GetToken(UsuarioLogueadoDTO usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var llave = Encoding.ASCII.GetBytes(_appSettings.KeySecretJWT);

            var tokenDesriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, usuario.IdUsuario.ToString()),
                        new Claim(ClaimTypes.Email, usuario.Correo)
                    }
                    ),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(llave), SecurityAlgorithms.HmacSha256)

            };

            var token = tokenHandler.CreateToken(tokenDesriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
