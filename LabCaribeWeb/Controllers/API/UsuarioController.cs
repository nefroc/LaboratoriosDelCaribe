using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Services.Interfaces;
using Models.DTOs.Usuario;

namespace LabCaribeWeb.Controllers.API
{
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("Autenticar")]
        public IActionResult Autenticar([FromBody] AccesoDTO login) {
            try
            {
                return Ok(_usuarioService.Autenticacion(login));
            }
            catch (Exception ex){
                return Problem(title: ex.Message, statusCode: 500);
            }
        }
    }
}
