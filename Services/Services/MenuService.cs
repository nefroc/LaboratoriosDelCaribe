using System;
using Services.Interfaces;
using Models.DTOs.Menu;
using DataBaseContext;
using System.Collections.Generic;
using System.Linq;

namespace Services.Services
{
    public class MenuService : IMenuService
    {

        private readonly LabDBContext _labDBContext;

        public MenuService(LabDBContext labDBContext)
        {
            _labDBContext = labDBContext;
        }

        public List<PerfilMenuDTO> GetPerfilMenu(int idPerfil) {
            List<PerfilMenuDTO> menu = new List<PerfilMenuDTO>();

            try
            {
                var query = _labDBContext.PerfilMenu.Join(
                        _labDBContext.Menu,
                        perfilMenu => perfilMenu.IdMenu,
                        menu => menu.Id,
                        (perfilMenu, menu) => new {
                            idMenu = menu.Id,
                            padreId = menu.PadreId,
                            nombre = menu.Nombre,
                            url = menu.Url,
                            iconClass = menu.IconClass
                        }
                    ).ToList();

                foreach (var item in query)
                {
                    menu.Add(new PerfilMenuDTO {
                        idMenu = item.idMenu,
                        padreId = item.padreId,
                        nombre = item.nombre,
                        url = item.url,
                        iconClass = item.iconClass
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
