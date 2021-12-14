using System;
using System.Collections.Generic;
using Models.DTOs.Usuario;

namespace Services.Interfaces
{
    public interface IUsuarioService
    {
        string SetNuevoUsuario(UsuarioDTO usuario);
        List<ListaUsuariosDTO> GetListaUsuarios();
        UsuarioLogueadoDTO Autenticacion(AccesoDTO login);
        bool SetEliminarUsuario(int idUsuario);
        string SetActualizarUsuario(UsuarioDTO usuario);
        UsuarioDTO GetUsuario(int id);
    }
}
