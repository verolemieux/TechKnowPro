using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TechKnowPro
{
    public class Survey
    {
        private int survey_id { get; set; }
        private int incident_id { get; set; }
        private string username { get; set; }
        private string response_time { get; set; }
        private string technician_efficiency { get; set; }
        private string problem_resolution { get; set; }
        private string additional_comments { get; set; }
        private bool contact_further { get; set; }
        private string contact_preference { get; set; }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True");

        public Survey(int s_id, int i_id, string u, string rt, string te, string pr, string ac, bool cf, string cp)
        {
            survey_id = s_id;
            incident_id = i_id;
            username = u;
            response_time = rt;
            technician_efficiency = te;
            problem_resolution = pr;
            additional_comments = ac;
            contact_further = cf;
            contact_preference = cp;
        }

        public void addSurveyToDatabase()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "INSERT INTO [Survey] (survey_id, incident_id, username, response_time, technician_efficiency, problem_resolution, additional_comments, contact_further, contact_preference)" +
                            " values('" + survey_id + "','" +incident_id + "','" +username + "','" +response_time + "','" +technician_efficiency + "','" +problem_resolution + "','" +additional_comments + "','" +contact_further + "','" +contact_preference+ "')";
            cmd.ExecuteNonQuery();
            con.Close();
        }
    
    }
}