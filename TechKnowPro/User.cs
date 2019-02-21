using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace TechKnowPro
{
    public class User
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public string password { get; set; }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True");

        public User(string firstName, string lastName, string address, string email, string password)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.address = address;
            this.email = email;
            this.password = password;
        }

        public void addUserToDatabase()
        {
            Random random = new Random();
            string activationCode = random.Next(1001, 9999).ToString();
                
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "insert into [User](Username,Password,First_Name,Last_Name,Address, Activation_Code) values('" + email + "','" + password + "','" + firstName + "','" + lastName + "','" + address + "','" + activationCode + "')";
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}