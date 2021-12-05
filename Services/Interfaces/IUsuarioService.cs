using System;
using System.Collections.Generic;
using DataBaseContext.Models;
using Models.DTOs.Usuario;

namespace Services.Interfaces
{
    public interface IUsuarioService
    {
        bool Add(Usuario usuario);
        List<Usuario> GetAll();
        UsuarioLogueadoDTO Autenticacion(AccesoDTO login);
    }
}
