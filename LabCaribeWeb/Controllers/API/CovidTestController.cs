using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs.CovidTest;
using Services.Interfaces;

namespace LabCaribeWeb.Controllers.API
{
    [Route("api/[controller]")]
    public class CovidTestController : ControllerBase
    {
        public readonly ICovidTestService _covidTestService;

        public CovidTestController(ICovidTestService covidTestService) {
            _covidTestService = covidTestService;
        }

        [HttpPost("SetCovidTest")]
        public IActionResult SetCovidTest([FromBody] CovidTestDTO covidTestDTO)
        {
            return Ok(_covidTestService.SetCovidTest(covidTestDTO));
        }
    }
}
