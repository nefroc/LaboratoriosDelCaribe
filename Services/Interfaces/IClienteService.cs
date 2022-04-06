using System;
using System.Collections.Generic;
using Models.DTOs;
using Models.DTOs.Cliente;

namespace Services.Interfaces
{
    public interface IClienteService
    {
        string SetCliente(ClienteDTO cliente);
        List<ClienteDTO> GetListaClientes();
        ClienteDTO GetCliente(int idCliente);
        string SetEliminarCliente(int id);
        List<ListaDTO> AutocompleteCliente(string texto);
    }
}
