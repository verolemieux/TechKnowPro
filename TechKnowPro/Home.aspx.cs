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
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            if (Session["User Type"] == null)
            {
                //if the user attempts to access a page that they are not authorized to view
                Session.Add("ErrorMessage", "You must successfully login before accessing the page!");
                Server.Transfer("~/Login.aspx");
            }
            else
            {
                //depending on user type, show different divs in home page
                if (Session["User Type"].ToString() == "admin")
                {
                    homeAdmin.Visible = true;
                }
                else if (Session["User Type"].ToString() == "tech")
                {
                    homeTech.Visible = true;
                }
                else if (Session["User Type"].ToString() == "customer" && Session["Verified"].ToString() == "no")
                {
                    homeCustomerUnverified.Visible = true;
                }
                else if (Session["User Type"].ToString() == "customer" && Session["Verified"].ToString() == "yes")
                {
                    homeCustomer.Visible = true;
                }
                lblWelcome.Text = "Welcome to the Tech Know Pro Support Portal, " + Session["First Name"] + "!";
            }
        }

        protected void BtnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login.aspx");
            Session.Abandon();
        }

        protected void btnResendEmail_Click(object sender, EventArgs e)
        {
            // if the user has lost the previous email sent, resend it
            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            message.From = new MailAddress("techknowpro.info@gmail.com");
            message.To.Add(new MailAddress(Session["Username"].ToString()));
            message.Subject = "Thank you for registering!";
            string verificationKey = Session["Verification Key"].ToString();
            string link = "http://localhost:8080/Login.aspx?key=" + verificationKey;
            message.Body = "Welcome " + Session["First Name"].ToString() + " " + Session["Last Name"].ToString() +
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
    }
}