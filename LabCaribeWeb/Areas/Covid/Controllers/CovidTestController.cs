using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LabCaribeWeb.Filters;
using LabCaribeWeb.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs.Cliente;
using Tools;

namespace LabCaribeWeb.Areas.Covid.Controllers
{
    [Area("Covid")]
    [SessionValidate]
    public class CovidTestController : Controller
    {
        private readonly ISessionManager _sessionManager;

        public CovidTestController(ISessionManager sessionManager)
        {
            _sessionManager = sessionManager;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
