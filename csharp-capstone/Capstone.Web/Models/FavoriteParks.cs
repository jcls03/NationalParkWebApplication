using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class FavoriteParks
    {
        public string ParkName { get; set; }
        public IList<Survey> GetSurveys { get; set; }

    }
}
