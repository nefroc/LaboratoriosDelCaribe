﻿using System;
using System.Threading.Tasks;
using LabCaribeWeb.Filters;
using LabCaribeWeb.Utility;
using Microsoft.AspNetCore.Mvc;
using Tools;
using Models.DTOs.Usuario;

namespace LabCaribeWeb.Areas.Catalogos.Controllers
{
    [Area("Catalogos")]
    public class UsuariosController : Controller
    {
        private readonly ISessionManager _sessionManager;

        public UsuariosController(ISessionManager sessionManager)
        {
            _sessionManager = sessionManager;
        }

        [SessionValidate]
        public IActionResult Index() {
            return View();
        }

        [HttpGet]
        [SessionValidate]
        public async Task<IActionResult> GetListaUsuarios() {
            RequestSender oRs = new RequestSender(Global.UrlAPI);
            dtoResult<ListaUsuariosDTO> usuarios = await oRs.GetList<ListaUsuariosDTO>("Usuario/GetListaUsuarios");

            if (usuarios.Estatus) {
                return new JsonResult(usuarios.result);
            }
            else {
                throw new Exception(usuarios.message);
            }
        }
    }
}
