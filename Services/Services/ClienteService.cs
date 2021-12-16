using System;
using System.Data;
using DataBaseContext;
using Microsoft.Extensions.Options;
using MySqlConnector;
using Services.Interfaces;
using Tools;
using Dapper;
using Models.DTOs.Cliente;

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
    }
}
