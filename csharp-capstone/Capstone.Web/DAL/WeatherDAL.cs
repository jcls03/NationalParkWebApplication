using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public class WeatherDAL : IWeatherDAL
    {
        // depend inject
        private string connectionString;


        public WeatherDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IList<ParkWeather> GetWeathers(string code)
        {
            IList<ParkWeather> parkWeathers = new List<ParkWeather>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * from weather WHERE parkCode = @parkCode", conn);
                    cmd.Parameters.AddWithValue("@parkCode", code);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ParkWeather parkWeather = new ParkWeather()
                        {
                            FiveDayForecast = Convert.ToInt32(reader["fiveDayForecastValue"]),
                            LowTemp = Convert.ToInt32(reader["low"]),
                            HighTemp = Convert.ToInt32(reader["high"]),
                            ParkCode = Convert.ToString(reader["parkCode"]),
                            Forecast = Convert.ToString(reader["forecast"])
                        };
                        parkWeathers.Add(parkWeather);

                    }
                }
                return parkWeathers;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // get one park
        //public ParkWeather GetWeather(string code)
        //{
        //    return GetWeathers(code).FirstOrDefault(b => b.ParkCode == code);
        //}
    }
}
