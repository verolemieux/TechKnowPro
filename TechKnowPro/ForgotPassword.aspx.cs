using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace TechKnowPro
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            string userName = txtUsername.Text;
            string postalCode = txtPostalCode.Text;
            string secretQuestion = DropDownListSecretQuestion.Text;
            string secretAnswer = txtSecretAnswer.Text;

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True");
            AppDomain.CurrentDomain.SetData("DataDirectory", System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Databases"));
            con.Open();
            string qry = "select * from [User]" + " where Username='" + userName + "' and Postal_Code ='" + postalCode + "' and Secret_Question ='" + secretQuestion + "' and Secret_Answer='" + secretAnswer + "'";
            SqlCommand cmd = new SqlCommand(qry, con);
            SqlDataReader sdr = cmd.ExecuteReader();

            if (sdr.Read())
            {
                lblChangePasswordSuccess.Text = "Password successfully changed! Click <a href='http://localhost:8080/Login.aspx'>here</a> to login!";
            }
            else
            {
                lblChangePasswordErr.Text = "Invalid User Information!";
            }
        }
    }
}