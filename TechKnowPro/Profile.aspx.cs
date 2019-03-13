using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TechKnowPro
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["UserType"] == null || Session["UserType"].ToString() != "customer")
            {
                Session["ErrorMessage"] = "You do not have permission to access this page.";
                if (Session["UserName"] == null) Response.Redirect("Login.aspx");
                Response.Redirect("Home.aspx");
            }

            
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True");
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT * FROM [User] WHERE Username = '" + Session["Username"].ToString()+ "'";
            cmd.ExecuteNonQuery();
            SqlDataReader sdr = cmd.ExecuteReader();

            if (sdr.Read())
            {
                // doesn't exist in the table
                // txtProfileName.Text = sdr["Profile_Name"].ToString();

                // show password in astericks
                // txtPassword.Text = sdr["Password"].ToString();
                

                txtUsername.Text = sdr["Username"].ToString();
                txtFirstName.Text = sdr["First_Name"].ToString();
                txtLastName.Text = sdr["Last_Name"].ToString();
                txtAddress.Text = sdr["Address"].ToString();
                txtEmail.Text = sdr["Username"].ToString();
            }
            
        }
    }
}