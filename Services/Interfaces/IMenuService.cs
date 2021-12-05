using System;
using System.Collections.Generic;
using Models.DTOs.Menu;

namespace Services.Interfaces
{
    public interface IMenuService
    {
        List<PerfilMenuDTO> GetPerfilMenu(int idPerfil);
    }
}
