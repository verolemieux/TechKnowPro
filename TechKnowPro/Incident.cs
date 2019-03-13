using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace TechKnowPro
{
    public class Incident
    {
        private string username { get; set; }
        private string date { get; set; }
        private int status { get; set; }
        private string description { get; set; }
        private int contact { get; set; }
        private int incidentNum { get; set; }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True");

        public Incident(int num, string u, string d, int s, string desc, int c)
        {
            username = u;
            date = d;
            status = s;
            description = desc;
            contact = c;
            incidentNum = num;
        }
        public void addIncidenttoDatabase()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "insert into [Incidents](Incident_Num,Date_Time,Status,Contact_Method,Username,Description) values('" + incidentNum + "','" + date + "','" + status + "','" + contact + "','" + username + "','" + description + "')";
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}