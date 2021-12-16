using System;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace LabCaribeWeb.Controllers.API
{
    [Route("api/[controller]")]
    public class PerfilController : ControllerBase
    {
        public readonly IPerfilService _perfilService;

        public PerfilController(IPerfilService perfilService) 
        {
            _perfilService = perfilService;
        }

        [HttpGet("GetPerfiles")]
        public IActionResult GetPerfiles() {
            return Ok(_perfilService.GetPerfiles());
        }
    }
}
