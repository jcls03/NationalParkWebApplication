using Capstone.Web.DAL;
using Capstone.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Controllers
{
    public class WeatherController : Controller
    {
        private IWeatherDAL weatherDAL;

        public WeatherController(IWeatherDAL weatherDAL)
        {
            this.weatherDAL = weatherDAL;
        }

        public IActionResult WeatherDetail(ParkWeather code)
        {

            var weather = weatherDAL.GetWeathers(code);

            return View(weather);

        }
    }
}
