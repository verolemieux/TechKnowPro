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

        protected void btnResetPassword_Click(object sender, EventArgs e)
        {
            string userName = txtUsername.Text.ToLower();
            string postalCode = txtPostalCode.Text.ToLower();
            string secretQuestion = DropDownListSecretQuestion.Text.ToLower();
            string secretAnswer = txtSecretAnswer.Text.ToLower();
            string newPassword = txtNewPassword.Text.ToLower();

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True");
            AppDomain.CurrentDomain.SetData("DataDirectory", System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Databases"));
            con.Open();
            string qry = "select * from [User]" + " where Username='" + userName + "' and Postal_Code ='" + postalCode + "' and Secret_Question ='" + secretQuestion + "' and Secret_Answer='" + secretAnswer + "'";
            SqlCommand cmd = new SqlCommand(qry, con);
            SqlDataReader sdr = cmd.ExecuteReader();

            if (sdr.Read())
            {
                string updateQry = "update [User] set Password='" + newPassword + "' where Username='" + userName + "'";
                SqlCommand cmd2 = new SqlCommand(updateQry, con);
                lblResetPasswordMessage.Text = "Password successfully changed! Click <a href='http://localhost:8080/Login.aspx'>here</a> to login!";
            }
            else
            {
                lblResetPasswordMessage.Text = "Information entered is incorrect - please verify!";
            }
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
            if (string.IsNullOrEmpty(this.txtNewPassword.Text.Trim()))
            {
                message = message + "New Password<br>";
            }
            if (string.IsNullOrEmpty(this.txtConfirmPassword.Text.Trim()))
            {
                message = message + "Password Confirmation<br>";
            }

            if (message.Length > 0)
            {
                args.IsValid = false;
                ((CustomValidator)source).ErrorMessage = @"&nbsp;Required fields missing:<br>" + message;
            }
        }
    }
}