using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LabCaribeWeb.Filters;
using LabCaribeWeb.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs.Cliente;
using Tools;

namespace LabCaribeWeb.Areas.Catalogos.Controllers
{
    [Area("Catalogos")]
    public class ClientesController : Controller
    {
        private readonly ISessionManager _sessionManager;

        public ClientesController(ISessionManager sessionManager) {
            _sessionManager = sessionManager;
        }

        [SessionValidate]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [SessionValidate]
        public async Task<IActionResult> SetCliente([FromBody] ClienteDTO cliente) {
            cliente.usuario = _sessionManager.IdUsuario;

            RequestSender requestSender = new RequestSender(Global.UrlAPI);
            dtoResult<string> result = await requestSender.Post<string>("Cliente/SetCliente", cliente);

            if (result.Estatus)
            {
                return new JsonResult(result.valor);
            }
            else
            {
                throw new Exception(result.message);
            }
        }
    }
}