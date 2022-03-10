using System;
using Models.DTOs.CovidTest;
namespace Services.Interfaces
{
    public interface ICovidTestService
    {
        string SetCovidTest(CovidTestDTO covidTestDTO);
    }
}
