using System;
using System.Collections.Generic;
using System.Data;
using DataBaseContext;
using Models.DTOs;
using Services.Interfaces;
using Tools;
using Dapper;
using System.Linq;
using MySqlConnector;
using Microsoft.Extensions.Options;

namespace Services.Services
{
    public class PerfilService : IPerfilService
    {
        private readonly LabDBContext _labDBContext;
        private readonly AppSettings _appSettings;
        private readonly IDbConnection _db;

        public PerfilService(LabDBContext labDBContext, IOptions<AppSettings> appSettings)
        {
            _labDBContext = labDBContext;
            _appSettings = appSettings.Value;

            _db = new MySqlConnection(Global.ConnectionString);
        }

        public List<ListaDTO> GetPerfiles() {
            List<ListaDTO> lista = null;

            try
            {
                using (var con = _db) {
                    lista = con.Query<ListaDTO>("select id, nombre as item from LabDelCaribe.Perfil where activo = 1").ToList();
                }
            }
            catch (Exception ex) {
                lista = null;
            }

            return lista;
        }
    }
}
