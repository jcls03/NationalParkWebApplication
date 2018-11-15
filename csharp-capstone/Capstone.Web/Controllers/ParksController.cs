using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.DAL;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Web.Controllers
{
    public class ParksController : Controller
    {

        //depend inject
        private IParkDAL parkDAL;

        public ParksController(IParkDAL parkDAL)
        {
            this.parkDAL = parkDAL;
        }

        //home
        public IActionResult Index()
        {

            var parks = parkDAL.GetParks();

            return View(parks);
        }

        //detail
        public IActionResult Detail(string code)
        {

            var parkinfo = parkDAL.GetPark(code);

            return View(parkinfo);
        }
    }
}