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

        [HttpPost("SetNuevoUsuario")]
        public IActionResult SetNuevoUsuario([FromBody] UsuarioDTO usuario) {
            return Ok(_usuarioService.SetNuevoUsuario(usuario));
        }

        [HttpGet("GetListaUsuarios")]
        //[Authorize]
        public IActionResult GetListaUsuarios() {
            return Ok(_usuarioService.GetListaUsuarios());
        }

        [HttpDelete("SetEliminarUsuario")]
        public IActionResult SetEliminarUsuario(int id) {
            return Ok(_usuarioService.SetEliminarUsuario(id));
        }

        [HttpPut("SetActualizarUsuario")]
        public IActionResult SetActualizarUsuario([FromBody] UsuarioDTO usuario) {
            return Ok(_usuarioService.SetActualizarUsuario(usuario));
        }

        [HttpGet("GetUsuario")]
        public IActionResult GetUsuario(int id) {
            return Ok(_usuarioService.GetUsuario(id));
        }
    }
}
