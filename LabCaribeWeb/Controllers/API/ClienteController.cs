using System;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs.Cliente;
using Services.Interfaces;

namespace LabCaribeWeb.Controllers.API
{
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        public readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpPost("SetCliente")]
        public IActionResult SetCliente([FromBody] ClienteDTO cliente)
        {
            return Ok(_clienteService.SetCliente(cliente));
        }
    }
}
