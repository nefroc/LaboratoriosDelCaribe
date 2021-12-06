using System;
using System.Collections.Generic;
using DataBaseContext.Models;
using Models.DTOs.Menu;

namespace Services.Interfaces
{
    public interface IMenuService
    {
        List<Menu> GetPerfilMenu(int idPerfil);
    }
}
