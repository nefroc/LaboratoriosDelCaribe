using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Services.Interfaces;
using Models.DTOs.Usuario;

namespace LabCaribeWeb.Controllers.API
{
    [Route("api/[controller]")]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        [HttpGet("GetPerfilMenu")]
        public IActionResult GetPerfilMenu(int idPerfil) {
            return Ok(_menuService.GetPerfilMenu(idPerfil));
        }
    }
}