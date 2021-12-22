using System;
using System.Data;
using DataBaseContext;
using Microsoft.Extensions.Options;
using MySqlConnector;
using Services.Interfaces;
using Tools;
using Dapper;
using Models.DTOs.Cliente;
using System.Collections.Generic;
using System.Linq;

namespace Services.Services
{
    public class ClienteService : IClienteService
    {
        private readonly LabDBContext _labDBContext;
        private readonly AppSettings _appSettings;
        private readonly IDbConnection _db;

        public ClienteService(LabDBContext labDBContext, IOptions<AppSettings> appSettings)
        {
            _labDBContext = labDBContext;
            _appSettings = appSettings.Value;
            _db = new MySqlConnection(Global.ConnectionString);
        }

        public string SetCliente(ClienteDTO cliente)
        {
            string mensaje = null;

            using (var con = _db)
            {
                con.Open();
                using (var tran = con.BeginTransaction())
                {
                    try
                    {
                        var p = new DynamicParameters();
                        p.Add("_id", cliente.id);
                        p.Add("_nombre", cliente.nombre);
                        p.Add("_edad", cliente.edad);
                        p.Add("_fechaNacimiento", cliente.fechaNacimiento);
                        p.Add("_sexo", cliente.sexo);
                        p.Add("_telefono", cliente.telefono);
                        p.Add("_nombreDoctor", cliente.nombreDoctor);
                        p.Add("_email", cliente.email);
                        p.Add("_numeroPasaporte", cliente.numeroPasaporte);
                        p.Add("_usuario", cliente.usuario);

                        mensaje = con.ExecuteScalar<string>("spSetCliente", p, tran, commandType: CommandType.StoredProcedure);
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

        public List<ClienteDTO> GetListaClientes()
        {
            List<ClienteDTO> clientes;

            using (var con = _db)
            {
                try
                {
                    clientes = con.Query<ClienteDTO>("select id, nombre, edad, fechaNacimiento, sexo, telefono, nombreDoctor, email, ifnull(numeroPasaporte, '') as numeroPasaporte, creadoPor as usuario " +
                                                     "from LabDelCaribe.Cliente").ToList();
                }
                catch (Exception ex)
                {
                    clientes = new List<ClienteDTO>();
                }
            }

            return clientes;
        }

        public ClienteDTO GetCliente(int idCliente)
        {
            ClienteDTO cliente = null;

            using (var con = _db)
            {
                try
                {
                    var client = con.QueryFirstOrDefault("select id, nombre, edad, fechaNacimiento, sexo, telefono, ifnull(nombreDoctor, '') as nombreDoctor, email, ifnull(numeroPasaporte, '') as numeroPasaporte, creadoPor as usuario " +
                                                         "from LabDelCaribe.Cliente where id = @idCliente", new { idCliente });
                    var data = (IDictionary<string, object>)client;

                    cliente = new ClienteDTO()
                    {
                        id = (int?)data["id"],
                        nombre = data["nombre"].ToString(),
                        edad = (int)data["edad"],
                        fechaNacimiento = (DateTime?)data["fechaNacimiento"],
                        sexo = data["sexo"].ToString(),
                        telefono = data["telefono"].ToString(),
                        nombreDoctor = data["nombreDoctor"].ToString(),
                        email = data["email"].ToString(),
                        numeroPasaporte = data["numeroPasaporte"].ToString(),
                        usuario = (int?)data["usuario"]
                    };
                }
                catch (Exception ex)
                {
                    cliente = null;
                }
            }

            return cliente;
        }

        public string SetEliminarCliente(int id)
        {
            string mensaje = null;

            using (var con = _db)
            {
                try
                {
                    var sql = "delete from LabDelCaribe.Cliente where id = @id";
                    con.Open();
                    con.Execute(sql, new { id });
                    mensaje = "ok";
                }
                catch (Exception ex) {
                    mensaje = ex.Message;
                }
            }

            return mensaje;
        }
    }
}
