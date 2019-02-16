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

        public User(string firstName, string lastName, string address, string email, string password)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.address = address;
            this.email = email;
            this.password = password;

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True");
            AppDomain.CurrentDomain.SetData("DataDirectory", System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Databases"));
            //con.Open();
            string qry = "insert [User] (Username, Password, First_Name, Last_Name, Address, User_Type) VALUES (" + email + ", " + password + ", " + firstName + ", " + lastName + ", " + address + ", 'customer')";
            SqlCommand cmd = new SqlCommand(qry, con);
            //con.Close();
        }
    }
}