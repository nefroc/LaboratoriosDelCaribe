using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using DataBaseContext;
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

        public string SetNuevoUsuario(UsuarioDTO usuario) {
            string mensaje = null;

            using (var con = _db) {
                con.Open();
                using (var tran = con.BeginTransaction())
                {
                    try
                    {
                        var p = new DynamicParameters();
                        p.Add("_correo", usuario.correo);
                        p.Add("_contrasena", Encrypt.EncryptString(usuario.contrasena));
                        p.Add("_nombre", usuario.nombre);
                        p.Add("_apellidos", usuario.apellidos);
                        p.Add("_activo", usuario.activo);
                        p.Add("_creadoPor", usuario.creadoPor);
                        p.Add("_idPerfil", usuario.idPerfil);

                        mensaje = con.ExecuteScalar<string>("spSetNuevoUsuario", p, tran, commandType: CommandType.StoredProcedure);
                        if (mensaje == "ok")
                        {
                            tran.Commit();
                        }
                        else {
                            tran.Rollback();
                        }
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        mensaje = ex.Message;
                    }
                }
            }

            return mensaje;
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
                    if (Encrypt.DecryptString(usuarioExiste.Contrasena) == login.Password)
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

        public bool SetEliminarUsuario(int id) {
            bool result = false;

            using (var con = _db)
            {
                var sql = "delete from LabDelCaribe.Usuario where id = @id";

                try
                {
                    con.Open();
                    con.Execute(sql, new { id });

                    result = true;
                }
                catch { }
                
            }

            return result;
        }

        public string SetActualizarUsuario(UsuarioDTO usuario) {
            string mensaje = null;

            using (var con = _db)
            {
                con.Open();
                using (var tran = con.BeginTransaction())
                {
                    try
                    {
                        var p = new DynamicParameters();
                        p.Add("_id", usuario.id);
                        p.Add("_correo", usuario.correo);
                        p.Add("_contrasena", Encrypt.EncryptString(usuario.contrasena));
                        p.Add("_nombre", usuario.nombre);
                        p.Add("_apellidos", usuario.apellidos);
                        p.Add("_activo", usuario.activo);
                        p.Add("_modificadoPor", usuario.creadoPor);
                        p.Add("_idPerfil", usuario.idPerfil);

                        mensaje = con.ExecuteScalar<string>("spSetActualizarUsuario", p, tran, commandType: CommandType.StoredProcedure);
                        if (mensaje == "ok")
                        {
                            tran.Commit();
                        }
                        else
                        {
                            tran.Rollback();
                        }
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        mensaje = ex.Message;
                    }
                }
            }

            return mensaje;
        }

        public UsuarioDTO GetUsuario(int id) {
            UsuarioDTO usuario = null;
            try
            {
                using (var conn = _db)
                {
                    var user = conn.QueryFirstOrDefault("select id, correo, contrasena, nombre, apellidos, activo, creadoPor, idPerfil " +
                                                       "from LabDelCaribe.Usuario " +
                                                       "where id = @id;", new { id });
                    var data = (IDictionary<string, object>)user;

                    usuario = new UsuarioDTO() {
                        id = (int)data["id"],
                        correo = data["correo"].ToString(),
                        contrasena = data["contrasena"].ToString(),
                        nombre = data["nombre"].ToString(),
                        apellidos = data["apellidos"].ToString(),
                        activo = (bool)data["activo"],
                        creadoPor = (int)data["creadoPor"],
                        idPerfil = (int?)data["idPerfil"]
                    };

                    try { usuario.contrasena = Encrypt.DecryptString(usuario.contrasena); }
                    catch { usuario.contrasena = ""; }
                }
            }
            catch (Exception ex)
            {
                usuario = null;
            }

            return usuario;
        }
    }
}
