using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace TechKnowPro
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            if (Session["User Type"] == null)
            {
                Session.Add("ErrorMessage", "You must successfully login before accessing the page!");
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                if (Session["User Type"].ToString() == "admin") homeAdmin.Visible = true;
                else if (Session["User Type"].ToString() == "tech") homeTech.Visible = true;
                else if (Session["User Type"].ToString() == "customer") homeCustomer.Visible = true;

                lblWelcome.Text = "Welcome to the Tech Know Pro Support Portal, " + Session["FirstName"] + "!";
            }
        }

        protected void BtnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login.aspx");
            Session.Abandon();
        }
    }
}
