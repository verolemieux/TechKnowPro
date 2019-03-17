using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TechKnowPro
{
    public partial class ConfirmSurvey : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            if (Session["User Type"] == null || Session["User Type"].ToString() != "customer")
            {
                Session["ErrorMessage"] = "You do not have permission to access this page.";
                if (Session["Username"] == null) Server.Transfer("Login.aspx");
                Server.Transfer("Home.aspx");
            }

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True");
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT * FROM [Surveys] WHERE Survey_Num = '" + Session["survey_num"].ToString() + "'";
            cmd.ExecuteNonQuery();
            SqlDataReader sdr = cmd.ExecuteReader();

            if (!IsPostBack)
            {
                if (sdr.Read())
                {
                    if (sdr["contact_further"].ToString() == "False")
                    {
                        lblContact.Visible = false;
                    }
                    
                }
            }


        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Session["Success"] = "false";
            Server.Transfer("Home.aspx");
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Server.Transfer("CreateSurvey.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Server.Transfer("~/Login.aspx");
        }
    }
}