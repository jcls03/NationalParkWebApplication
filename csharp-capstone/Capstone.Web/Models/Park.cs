using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class Park
    {
        public string Description { get; set; }
        public string ParkImage { get; set; }
        public IList<Park> Parks { get; set; }
        public string ParkCode { get; set; }
        public string ParkName { get; set; }
        public string State { get; set; }
        public int Acreage { get; set; }
        public int ElevationFt { get; set; }
        public double MilesOfTrail { get; set; }
        public int NoOfCampsites { get; set; }
        public string Climate { get; set; }
        public int YearFounded { get; set; }
        public int AnlVisitors { get; set; }
        public string Quote { get; set; }
        public string QuoteSource { get; set; }
        public int EntryFee { get; set; }
        public int NoOfSpecies { get; set; }
        public int FiveDayForecast { get; set; }
        public int LowTemp { get; set; }
        public int HighTemp { get; set; }
        public string Forecast { get; set; }
    }
}
