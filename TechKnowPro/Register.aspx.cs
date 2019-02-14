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
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            var firstName = "";
            var lastName = "";
            var address = "";
            var email = "";
            var password = "";

            if (Page.IsValid)
            {
                sendRegistrationEmail();
                lblSuccessfulRegistration.Text = "You have successfully registered! An email was sent to " + txtEmail.Text + " - please verify to confirm.";
            }

        }

        protected void sendRegistrationEmail()
        {
            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            message.From = new MailAddress("techknowpro.info@gmail.com");
            message.To.Add(new MailAddress(txtEmail.Text));
            message.Subject = "Thank you for registering!";
            message.Body = "Welcome " + txtFirstName.Text + " " + txtLastName.Text + "! <br /><br />Thank you for registering with TechKnow Pro Incident Report Management Software.<br />Please <a href='http://localhost:8080/Login.aspx'>login</a> to verify your email and complete your profile!<br /><br />Kindly reply to this email with any questions.<br /><br />TechKnow Pro Support";
            message.IsBodyHtml = true;
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("techknowpro.info@gmail.com", "logcfyyrmxtpcwdu");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Send(message);
        }

       
    }
}