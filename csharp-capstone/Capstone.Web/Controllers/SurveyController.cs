using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Web.Controllers
{
    public class SurveyController : Controller
    {
        //survey index
        public IActionResult Index()
        {
            return View();
        }

        //survey results
        public IActionResult SurveyResult()
        {
            return View();
        }
    }
}