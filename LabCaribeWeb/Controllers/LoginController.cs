using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

using LabCaribeWeb.Utility;
using Models.DTOs.Usuario;
using Models.DTOs.Menu;
using Tools;

namespace LabCaribeWeb.Controllers
{
    public class LoginController : Controller
    {
        private readonly ISessionManager _sessionManager;

        public LoginController(ISessionManager sessionManager) {
            _sessionManager = sessionManager;       
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (_sessionManager.Correo != null) {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index([FromForm] AccesoDTO login) {
            if (!ModelState.IsValid)
            {
                return View(login);
            }
            else {
                RequestSender.destroy();
                RequestSender oRS = new RequestSender(Global.UrlAPI);
                dtoResult<UsuarioLogueadoDTO> respuestaLogin = await oRS.Post<UsuarioLogueadoDTO>("Usuario/Autenticar", login);
                if (respuestaLogin.Estatus)
                {
                    if (respuestaLogin.valor.Mensaje == null)
                    {
                        _sessionManager.IdUsuario = (int)respuestaLogin.valor.IdUsuario;
                        _sessionManager.Nombre = respuestaLogin.valor.Nombre;
                        _sessionManager.Apellidos = respuestaLogin.valor.Apellidos;
                        _sessionManager.Correo = respuestaLogin.valor.Correo;
                        _sessionManager.IdPerfil = respuestaLogin.valor.IdPerfil != null ? (int)respuestaLogin.valor.IdPerfil : 0;
                        _sessionManager.Token = respuestaLogin.valor.Token;

                        List<PerfilMenuDTO> Menus = this.GetMenuPerfil(respuestaLogin.valor.IdPerfil != null ? (int)respuestaLogin.valor.IdPerfil : 0).GetAwaiter().GetResult();

                        HttpContext.Session.Set("Menu", Menus);
                    }
                    else {
                        return View(login);
                    }
                }
                else {
                    throw new Exception(respuestaLogin.message);
                }
            }

            return RedirectToAction(actionName: "Index", controllerName: "Home");
        }

        private async Task<List<PerfilMenuDTO>> GetMenuPerfil(int idPerfil)
        {
            RequestSender oRS = new RequestSender(Global.UrlAPI);

            dtoResult<PerfilMenuDTO> listMenu = await oRS.GetList<PerfilMenuDTO>("menu/GetPerfilMenu?idPerfil=" + idPerfil);

            if (listMenu.Estatus)
                return listMenu.result;
            else
                throw new Exception(listMenu.message);
        }
    }
}