using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LabCaribeWeb.Filters;
using LabCaribeWeb.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs;
using Models.DTOs.Cliente;
using Tools;

namespace LabCaribeWeb.Areas.Catalogos.Controllers
{
    [Area("Catalogos")]
    [SessionValidate]
    public class ClientesController : Controller
    {
        private readonly ISessionManager _sessionManager;

        public ClientesController(ISessionManager sessionManager) {
            _sessionManager = sessionManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
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

        [HttpGet]
        public async Task<IActionResult> GetListaClientes() {
            RequestSender requestSender = new RequestSender(Global.UrlAPI);
            dtoResult<ClienteDTO> result = await requestSender.GetList<ClienteDTO>("Cliente/GetListaClientes");
            if (result.Estatus)
            {
                return new JsonResult(result.result);
            }
            else {
                throw new Exception(result.message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetCliente(int idCliente)
        {
            RequestSender requestSender = new RequestSender(Global.UrlAPI);
            dtoResult<ClienteDTO> result = await requestSender.Get<ClienteDTO>("Cliente/GetCliente?idCliente=" + idCliente);
            if (result.Estatus)
            {
                return new JsonResult(result.valor);
            }
            else
            {
                throw new Exception(result.message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> SetEliminarCliente(int idCliente) {
            RequestSender requestSender = new RequestSender(Global.UrlAPI);
            dtoResult<string> result = await requestSender.Delet<string>("Cliente/SetEliminarCliente?id=" + idCliente);
            if (result.Estatus)
            {
                return new JsonResult(result.valor);
            }
            else {
                throw new Exception(result.message);
            }
        }

        [HttpGet("AutocompleteCliente")]
        public async Task<IActionResult> AutocompleteCliente(string texto) {
            RequestSender requestSender = new RequestSender(Global.UrlAPI);
            dtoResult<ListaDTO> result = await requestSender.GetList<ListaDTO>("Cliente/AutocompleteCliente?texto=" + texto);
            if (result.Estatus)
            {
                return new JsonResult(result.result);
            }
            else {
                return new JsonResult(new List<ListaDTO>());
            }
        }
    }
}