using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class Survey
    {
        public int SurveyID { get; set; }
        public string ParkCode { get; set; }
        [Required(ErrorMessage ="Email required")]
        public string Email { get; set; }
        [Required(ErrorMessage ="State of residence required")]
        public string State { get; set; }
        [Required(ErrorMessage ="Activity level required")]
        public string ActivityLevel { get; set; }
        public int NoOfSurveys { get; set; }
        [Required(ErrorMessage ="Park required")]
        public string NameOfPark { get; set; }
        [Required(ErrorMessage ="Name required")]
        public string Name { get; set; }

        public IList<Survey> surveys { get; set; }
    }
}
