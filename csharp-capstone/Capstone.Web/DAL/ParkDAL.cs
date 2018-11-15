using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public class ParkDAL : IParkDAL
    {
        // depend inject
        private string connectionString;

        public ParkDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        // get all parks
        public IList<Park> GetParks()
        {
            IList<Park> parks = new List<Park>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Park Order By parkName", conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Park park = new Park()
                        {
                            ParkName = Convert.ToString(reader["parkName"]),
                            State = Convert.ToString(reader["state"]),
                            Description = Convert.ToString(reader["parkDescription"]),
                            ParkCode = Convert.ToString(reader["parkCode"]),
                            Acreage = Convert.ToInt32(reader["acreage"]),
                            ElevationFt = Convert.ToInt32(reader["elevationInFeet"]),
                            MilesOfTrail = Convert.ToInt32(reader["milesOfTrail"]),
                            NoOfCampsites = Convert.ToInt32(reader["numberOfCampsites"]),
                            Climate = Convert.ToString(reader["climate"]),
                            YearFounded = Convert.ToInt32(reader["yearFounded"]),
                            AnlVisitors = Convert.ToInt32(reader["annualVisitorCount"]),
                            Quote = Convert.ToString(reader["inspirationalQuote"]),
                            QuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]),
                            EntryFee = Convert.ToInt32(reader["entryFee"]),
                            NoOfSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"])
                        };
                        parks.Add(park);
                    }
                }
                return parks;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Park GetPark(string code)
        {
            return GetParks().FirstOrDefault(q => q.ParkCode == code);
        }

        //// get one park
        //public Park GetPark(string code)
        //{
            
        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(connectionString))
        //        {
        //            conn.Open();
        //            SqlCommand cmd = new SqlCommand("SELECT * FROM park WHERE parkcode = @parkcode", conn);
        //            SqlDataReader reader = cmd.ExecuteReader();
        //            while (reader.Read())
        //            {
        //                Park park = new Park()
        //                {
        //                    ParkName = Convert.ToString(reader["parkName"]),
        //                    State = Convert.ToString(reader["state"]),
        //                    Description = Convert.ToString(reader["parkDescription"]),
        //                    ParkCode = Convert.ToString(reader["parkCode"]),
        //                    Acreage = Convert.ToInt32(reader["acreage"]),
        //                    ElevationFt = Convert.ToInt32(reader["elevationInFeet"]),
        //                    MilesOfTrail = Convert.ToInt32(reader["milesOfTrail"]),
        //                    NoOfCampsites = Convert.ToInt32(reader["numberOfCampsites"]),
        //                    Climate = Convert.ToString(reader["climate"]),
        //                    YearFounded = Convert.ToInt32(reader["yearFounded"]),
        //                    AnlVisitors = Convert.ToInt32(reader["annualVisitorCount"]),
        //                    Quote = Convert.ToString(reader["inspirationalQuote"]),
        //                    QuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]),
        //                    EntryFee = Convert.ToInt32(reader["entryFee"]),
        //                    NoOfSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"])
        //                };

        //            }
        //        }
        //        return park;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}
    }
}
