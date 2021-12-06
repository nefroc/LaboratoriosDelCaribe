using System;
using Services.Interfaces;
using Models.DTOs.Menu;
using DataBaseContext;
using System.Collections.Generic;
using System.Linq;
using DataBaseContext.Models;

namespace Services.Services
{
    public class MenuService : IMenuService
    {

        private readonly LabDBContext _labDBContext;

        public MenuService(LabDBContext labDBContext)
        {
            _labDBContext = labDBContext;
        }

        public List<Menu> GetPerfilMenu(int idPerfil) {
            List<Menu> menu = new List<Menu>();

            try
            {
                var query = _labDBContext.PerfilMenu.Join(
                        _labDBContext.Menu,
                        perfilMenu => perfilMenu.IdMenu,
                        menu => menu.Id,
                        (perfilMenu, menu) => new {
                            Id = menu.Id,
                            PadreId = menu.PadreId == null ? 0 : menu.PadreId,
                            Nombre = menu.Nombre,
                            Url = menu.Url,
                            IconClass = menu.IconClass,
                            CreadoPor = menu.CreadoPor,
                            Creado = menu.Creado
                        }
                    ).ToList();

                foreach (var item in query)
                {
                    menu.Add(new Menu {
                        Id = item.Id,
                        PadreId = item.PadreId,
                        Nombre = item.Nombre,
                        Url = item.Url,
                        IconClass = item.IconClass,
                        CreadoPor = item.CreadoPor,
                        Creado = item.Creado
                    });
                }
            }
            catch (Exception ex) {
                menu = null;
            }

            return menu;
        }
    }
}
