using System;
using System.Data;
using Services.Interfaces;
using Models.DTOs.CovidTest;
using Tools;
using Dapper;
using Models.DTOs.Cliente;
using System.Collections.Generic;
using System.Linq;
using DataBaseContext;
using MySqlConnector;
using Microsoft.Extensions.Options;

namespace Services.Services
{
    public class CovidTestService : ICovidTestService
    {
        private readonly LabDBContext _labDBContext;
        private readonly AppSettings _appSettings;
        private readonly IDbConnection _db;

        public CovidTestService(LabDBContext labDBContext, IOptions<AppSettings> appSettings)
        {
            _labDBContext = labDBContext;
            _appSettings = appSettings.Value;
            _db = new MySqlConnection(Global.ConnectionString);
        }

        public string SetCovidTest(CovidTestDTO covidTestDTO) {
            string mensaje = null;

            using (var con = _db) {
                con.Open();

                using (var tran = con.BeginTransaction()) {
                    try
                    {
                        var p = new DynamicParameters();
                        p.Add("_id", covidTestDTO.id);
                        p.Add("_idCliente", covidTestDTO.idCliente);
                        p.Add("_idCatalogoTest", covidTestDTO.idCatalogoTest);
                        p.Add("_resultado", covidTestDTO.resultado);
                        p.Add("_numeroAutorizacion", covidTestDTO.numeroAutorizacion);
                        p.Add("_rdrp", covidTestDTO.rdrp);
                        p.Add("_usuario", covidTestDTO.usuario);

                        mensaje = con.ExecuteScalar<string>("SetCovidTest", p, tran, commandType: CommandType.StoredProcedure);
                        if (mensaje == "ok")
                        {
                            tran.Commit();
                        }
                        else {
                            tran.Rollback();
                        }
                    }
                    catch (Exception ex) {
                        tran.Rollback();
                        mensaje = ex.Message;
                    }
                }
            }

                return mensaje;
        }
    }
}
