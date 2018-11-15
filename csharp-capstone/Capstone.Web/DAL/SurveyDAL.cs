using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public class SurveyDAL : ISurveyDAL
    {
        private readonly string connectionString;

        public SurveyDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        // conn for list of surveys
        public IList<Survey> GetSurveys()
        {
            IList<Survey> surveys = new List<Survey>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT parkName, COUNT('parkCode') AS 'ParkCount' FROM survey_result INNER JOIN park ON survey_result.parkCode = park.parkCode GROUP BY parkName ORDER BY ParkCount DESC;", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Survey survey = new Survey()
                        {
                            NameOfPark = Convert.ToString(reader["parkName"]),
                            NoOfSurveys = Convert.ToInt32(reader["ParkCount"]),
                            
                        };
                        surveys.Add(survey);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return surveys;
        }

        // save survey 
        public void SaveSurvey(Survey survey)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO survey_result VALUES (@parkCode, @emailAddress, @state, @activityLevel);", conn);
                    cmd.Parameters.AddWithValue("@parkCode", survey.ParkCode);
                    cmd.Parameters.AddWithValue("@emailAddress", survey.Email);
                    cmd.Parameters.AddWithValue("@state", survey.State);
                    cmd.Parameters.AddWithValue("@activityLevel", survey.ActivityLevel);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
        }

    }
}
