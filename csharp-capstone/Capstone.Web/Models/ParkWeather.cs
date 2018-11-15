using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class ParkWeather
    {
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
        public string Description { get; set; }
        public int EntryFee { get; set; }
        public int NoOfSpecies { get; set; }
        public int FiveDayForecast { get; set; }
        public double LowTemp { get; set; }
        public double HighTemp { get; set; }
        public string Forecast { get; set; }
        public IList<ParkWeather> parkWeathers { get; set; }
        public string TempUnits { get; set; }

        public void TemperatureConvert()
        {
            //if (this.TempUnits == "F")
            //{
            //    LowTemp = (LowTemp * 9 / 5) + 32;
            //    HighTemp = (HighTemp * 9 / 5) + 32
            //}


            if (TempUnits == "C")
            {
                LowTemp = (LowTemp - 32) * 5 / 9;
                HighTemp = (HighTemp - 32) * 5 / 9; 
            }
        }
    }
}
