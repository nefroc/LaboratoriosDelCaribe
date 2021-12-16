using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LabCaribeWeb.Filters;
using LabCaribeWeb.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LabCaribeWeb.Areas.Catalogos.Controllers
{
    [Area("Catalogos")]
    public class ClientesController : Controller
    {
        private readonly ISessionManager _sessionManager;

        public ClientesController(ISessionManager sessionManager) {
            _sessionManager = sessionManager;
        }

        [SessionValidate]
        public IActionResult Index()
        {
            return View();
        }
    }
}