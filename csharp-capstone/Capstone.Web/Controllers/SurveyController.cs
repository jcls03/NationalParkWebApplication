using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.DAL;
using Capstone.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Web.Controllers
{
    public class SurveyController : Controller
    {
        //depend inject
        private ISurveyDAL surveyDAL;

        public SurveyController(ISurveyDAL surveyDAL)
        {
            this.surveyDAL = surveyDAL;
        }
        //survey index
        public IActionResult Index()
        {
            return View();
        }

        //survey results
        [HttpGet]
        public IActionResult SurveyResult()
        {
            var result = surveyDAL.GetSurveys();
            return View(result);
        }

        //[HttpGet]
        //public IActionResult SaveSurvey()
        //{
        //    var survey = new Survey();
        //    return View(survey);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult SaveSurvey(Survey survey)
        //{
        //    surveyDAL.SaveSurvey(survey);
        //    return RedirectToAction("SurveyResult", "Survey");
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SurveyResult(Survey survey)
        {
            surveyDAL.SaveSurvey(survey);
            return RedirectToAction("SurveyResult", "Survey");
        }
    }
}