using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using LabCaribeWeb.Models;
using Services.Interfaces;
using LabCaribeWeb.Utility;
using LabCaribeWeb.Filters;
using Tools;
using DataBaseContext.Models;

namespace LabCaribeWeb.Controllers
{
    [TypeFilter(typeof(SessionValidate))]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISessionManager _sessionManeger;

        public HomeController(ILogger<HomeController> logger, ISessionManager sessionManeger)
        {
            _logger = logger;
            _sessionManeger = sessionManeger;
        }

        public IActionResult Index()
        {
            ViewBag.NombreUsuario = _sessionManeger.Nombre + " " + _sessionManeger.Apellidos;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
