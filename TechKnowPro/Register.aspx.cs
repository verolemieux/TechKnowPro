using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;

namespace TechKnowPro
{
    public partial class Register : System.Web.UI.Page
    {
        private User newUser;

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string userName = txtEmail.Text;
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "select * from [User]" + " where Username='" + userName + "'";
                cmd.ExecuteNonQuery();
                SqlDataReader sdr = cmd.ExecuteReader();
                
                if (sdr.Read())
                {
                    //if the username was found in the database/has previously been registered
                    lblSuccessfulRegistration.Text = "An account has already been registered with your email!";
                    con.Close();
                }
                else
                {
                    //if the user is new to the system:
                        //generate random verification key
                        //send registration email
                        //add user to database
                    Random random = new Random();
                    string verificationKey = BCrypt.Net.BCrypt.HashPassword(random.Next(0, 1000).ToString());
                    Session["Key"] = verificationKey;
                    sendRegistrationEmail();
                    con.Close();
                    newUser = new User(txtFirstName.Text, txtLastName.Text, txtAddress.Text, txtEmail.Text, txtPassword.Text, verificationKey, txtphone.Text);
                    newUser.addUserToDatabase();
                    lblSuccessfulRegistration.Text = "You have successfully registered! An email was sent to " + userName + " - please verify to confirm email address.";
                }
            }
        }

        protected void sendRegistrationEmail()
        {
            //send registration email that contains verification key as key-value pair
            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            message.From = new MailAddress("techknowpro.info@gmail.com");
            message.To.Add(new MailAddress(txtEmail.Text));
            message.Subject = "Thank you for registering!";
            string verificationKey = Session["Key"].ToString();
            string link = "http://localhost:8080/Login.aspx?key=" + verificationKey;
            message.Body = "Welcome " + txtFirstName.Text + " " + txtLastName.Text + 
                "! <br /><br />Thank you for registering with TechKnow Pro Incident Report Management Software.<br />" +
                "Please <a href='" + link + "'>login</a> to verify your email and complete your profile!<br /><br />Kindly reply to this email with any questions.<br /><br />TechKnow Pro Support";
            message.IsBodyHtml = true;
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("techknowpro.info@gmail.com", "logcfyyrmxtpcwdu");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Send(message);
        }

        protected void CustomValidatorMissingFields_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // custom validator that checks if every registration textbox has been filled
            string message = "";
            if (string.IsNullOrEmpty(this.txtFirstName.Text.Trim()))
                message = message + "First Name<br>";
            if (string.IsNullOrEmpty(this.txtLastName.Text.Trim()))
                message = message + "Last Name<br>";
            if (string.IsNullOrEmpty(this.txtAddress.Text.Trim()))
                message = message + "Address<br>";
            if (string.IsNullOrEmpty(this.txtEmail.Text.Trim()))
                message = message + "Email<br>";
            if (string.IsNullOrEmpty(this.txtphone.Text.Trim()))
                message = message + "Phone Number<br>";
            if (string.IsNullOrEmpty(this.txtPassword.Text.Trim()))
                message = message + "Password<br>";
            if (string.IsNullOrEmpty(this.txtConfirmPassword.Text.Trim()))
                message = message + "Password Confirmation<br>";
            if (cbTerms.Checked == false)
                message = message + "Terms of Service Agreement";
            if (message.Length > 0)
            { 
                args.IsValid = false;
                ((CustomValidator)source).ErrorMessage = @"&nbsp;Required fields missing:<br><br>" + message;
            }
        }
    }
}