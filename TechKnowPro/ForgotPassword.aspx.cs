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

        protected void CustomValidatorMissingFields_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string message = "";
            if (string.IsNullOrEmpty(this.txtUsername.Text.Trim()))
            {
                message = message + "Username<br>";
            }
            if (string.IsNullOrEmpty(this.txtPostalCode.Text.Trim()))
            {
                message = message + "Postal Code<br>";
            }
            if (string.IsNullOrEmpty(this.DropDownListSecretQuestion.Text.Trim()))
            {
                message = message + "Secret Question<br>";
            }
            if (string.IsNullOrEmpty(this.txtSecretAnswer.Text.Trim()))
            {
                message = message + "Secret Answer<br>";
            }

            if (message.Length > 0)
            {
                args.IsValid = false;
                ((CustomValidator)source).ErrorMessage = @"&nbsp;Required fields missing:<br>" + message;
            }
        }

        protected void btnVerifyInformation_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True");

            string userName = txtUsername.Text.ToLower();
            string postalCode = txtPostalCode.Text;
            string secretQuestion = DropDownListSecretQuestion.SelectedItem.Text;
            string secretAnswer = txtSecretAnswer.Text.ToLower();

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from [User]" + " where Username='" + userName + "' and Postal_Code ='" + postalCode + "' and Secret_Question ='" + secretQuestion + "' and Secret_Answer='" + secretAnswer + "'";
            cmd.ExecuteNonQuery();
            SqlDataReader sdr = cmd.ExecuteReader();

            if (sdr.Read())
            {
                lblNewPassword.Visible = true;
                txtNewPassword.Visible = true;

                lblConfirmPassword.Visible = true;
                txtConfirmPassword.Visible = true;
               
                btnResetPassword.Visible = true;
            }
            else
            {
                lblResetPasswordMessage.Text = "Information entered is incorrect - please verify!";
            }

            con.Close();
        }

        protected void btnResetPassword_Click(object sender, EventArgs e)
        {
            string newPassword = txtNewPassword.Text;
            string userName = txtUsername.Text;

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True");

            con.Open();
            SqlCommand cmd2 = con.CreateCommand();
            cmd2.CommandType = System.Data.CommandType.Text;
            cmd2.CommandText = "update [User] set Password='" + newPassword + "' where Username='" + userName + "'";
            cmd2.ExecuteNonQuery();
            lblResetPasswordMessage.Text = "Password successfully changed! Click <a href='http://localhost:8080/Login.aspx'>here</a> to login!";
            con.Close();
        }
    }
}