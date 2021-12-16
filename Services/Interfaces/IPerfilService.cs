using System;
using System.Collections.Generic;
using Models.DTOs;

namespace Services.Interfaces
{
    public interface IPerfilService
    {
        List<ListaDTO> GetPerfiles();
    }
}
