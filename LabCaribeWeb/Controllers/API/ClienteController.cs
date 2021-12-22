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

        [HttpGet("GetListaClientes")]
        public IActionResult GetListaClientes() {
            return Ok(_clienteService.GetListaClientes());
        }

        [HttpGet("GetCliente")]
        public IActionResult GetCliente(int idCliente) {
            return Ok(_clienteService.GetCliente(idCliente));
        }

        [HttpDelete("SetEliminarCliente")]
        public IActionResult SetEliminarCliente(int id) {
            return Ok(_clienteService.SetEliminarCliente(id));
        }
    }
}
