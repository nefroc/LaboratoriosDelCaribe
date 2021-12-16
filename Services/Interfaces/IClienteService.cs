using System;
using Models.DTOs.Cliente;

namespace Services.Interfaces
{
    public interface IClienteService
    {
        string SetCliente(ClienteDTO cliente);
    }
}
