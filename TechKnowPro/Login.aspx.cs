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
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username.Trim()) || string.IsNullOrEmpty(password.Trim()))
            {
                //if the user did not enter username or password
                Server.Transfer("~/Login.aspx");
            }
            else if (Page.IsValid)
            {
                //if the user entered username and password
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "select * from [User]" + " where Username='" + username + "'";
                cmd.ExecuteNonQuery();
                SqlDataReader sdr = cmd.ExecuteReader();

                if (sdr.Read())
                {
                    //if the username has been registered
                    sdr.Close();
                    DataSet dataSet = new DataSet();
                    SqlDataAdapter dAdapter = new SqlDataAdapter(cmd);
                    dAdapter.Fill(dataSet);
                    string hashedPassword = dataSet.Tables[0].Rows[0]["Password"].ToString();

                    if (BCrypt.Net.BCrypt.Verify(password, hashedPassword))
                    {
                        //if the password is correct
                        if (dataSet.Tables[0].Rows[0]["Verified"].ToString() == "no")
                        {
                            //if the user hasn't verified their email
                            String verified = "no";
                            if (Request.QueryString["key"] != null)
                            {
                                string verificationKey = dataSet.Tables[0].Rows[0]["Verification_Key"].ToString();
                                if (Request.QueryString["key"] == verificationKey)
                                {
                                    SqlCommand cmd2 = con.CreateCommand();
                                    cmd2.CommandType = System.Data.CommandType.Text;
                                    cmd2.CommandText = "update [User] set Verified = 'yes' where Username='" + username + "'";
                                    cmd2.ExecuteNonQuery();
                                    verified = "yes";
                                }
                            }
                            Session.Add("Verified", verified);
                            Session.Add("Verification Key", dataSet.Tables[0].Rows[0]["Verification_Key"].ToString());
                        }
                        else
                        {
                            //if the user has verified their email
                            Session.Add("Verified", "yes");
                        }
                        Session.Add("Username", username);
                        Session.Add("User Type", dataSet.Tables[0].Rows[0]["User_Type"].ToString());
                        Session.Add("First Name", dataSet.Tables[0].Rows[0]["First_Name"].ToString());
                        Session.Add("Last Name", dataSet.Tables[0].Rows[0]["Last_Name"].ToString());
                        Response.Redirect("~/Home.aspx");
                    }
                    else
                    {
                        //if the password is incorrect
                        lblLoginErr.Text = "Invalid Username and/or Password!";
                    }  
                }
                else
                {
                    //if the username is incorrect
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