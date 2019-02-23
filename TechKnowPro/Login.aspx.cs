using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace TechKnowPro
{
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            if (Session["ErrorMessage"] != null) lblLoginErr.Text = Session["ErrorMessage"].ToString();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Session.Remove("ErrorMessage");
            string userName = txtUsername.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(userName.Trim()) || string.IsNullOrEmpty(password.Trim()))
            {
                Response.Redirect("~/Login.aspx");
            }
            else if (Page.IsValid)
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "select * from [User]" + " where Username='" + userName + "'";
                cmd.ExecuteNonQuery();
                SqlDataReader sdr = cmd.ExecuteReader();

                if (sdr.Read())
                {
                    sdr.Close();
                    DataSet dataSet = new DataSet();
                    SqlDataAdapter dAdapter = new SqlDataAdapter(cmd);
                    dAdapter.Fill(dataSet);
                    string hashedPassword = dataSet.Tables[0].Rows[0]["Password"].ToString();

                    if (BCrypt.Net.BCrypt.Verify(password, hashedPassword))
                    {
                        Session.Add("UserName", userName);
                        Session.Add("UserType", dataSet.Tables[0].Rows[0]["User_Type"].ToString());
                        Session.Add("FirstName", dataSet.Tables[0].Rows[0]["First_Name"].ToString());

                        Response.Redirect("~/Home.aspx");
                    }
                    else
                    {
                        lblLoginErr.Text = "Invalid Username and/or Password!";
                    }  
                }
                else
                {
                    lblLoginErr.Text = "Invalid Username and/or Password!";
                }
                con.Close();
            }           
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Register.aspx");
        }
    }
}