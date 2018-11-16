using Capstone.Web.DAL;
using Capstone.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Capstone.Web.Extensions;

namespace Capstone.Web.Controllers
{
    public class WeatherController : Controller
    {
        private IWeatherDAL weatherDAL;

        public WeatherController(IWeatherDAL weatherDAL)
        {
            this.weatherDAL = weatherDAL;
        }

        public IActionResult WeatherDetail(string code)
        {

            var weather = weatherDAL.GetWeathers(code);
            string unit = GetCurrentTemperature();
            foreach(var w in weather)
            {
                w.TempUnits = unit;
                w.TemperatureConvert();
            }

            return View(weather);

        }

        public IActionResult ToggleTemp(string code)
        {
            string currentTemp = GetCurrentTemperature();

            if(currentTemp == "C")
            {
                SaveCurrentTemperature("F");
            }
            else
            {
                SaveCurrentTemperature("C");
            }
            return RedirectToAction("weatherdetail", new { /*code =*/ code });
        }

        private void SaveCurrentTemperature(string weather)
        {
            HttpContext.Session.Set<string>("Temp", weather);
        }

        private string GetCurrentTemperature()
        {

            if (HttpContext.Session.Get<string>("Temp") == null)
            {
                HttpContext.Session.Set<string>("Temp", "C");
            }
            return HttpContext.Session.Get<string>("Temp");
        }

        public IActionResult TemperatureConvert()
        {
            return null;
        }
    }
}
