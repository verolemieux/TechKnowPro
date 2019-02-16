using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechKnowPro
{
    public class User
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string userType { get; set; }

        public User(string firstName, string lastName, string address, string email, string password)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.address = address;
            this.email = email;
            this.password = password;
            this.userType = "customer";
        }
    }
}