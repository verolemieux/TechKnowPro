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
        public string verificationKey { get; set; }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True");

        public User(string firstName, string lastName, string address, string email, string password, string verificationKey)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.address = address;
            this.email = email;
            this.password = BCrypt.Net.BCrypt.HashPassword(password);
            this.verificationKey = verificationKey;
        }

        public void addUserToDatabase()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "insert into [User](Username,Password,First_Name,Last_Name,Address,User_Type, Verification_Key, Verified) values('" + email + "','" + password + "','" + firstName + "','" + lastName + "','" + address + "','customer','" + verificationKey + "','no')";
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}