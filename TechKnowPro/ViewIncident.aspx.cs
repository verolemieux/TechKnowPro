using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace TechKnowPro
{
    public partial class ViewIncident : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            if (Session["User Type"] == null || Session["User Type"].ToString() != "tech")
            {
                Session["ErrorMessage"] = "You do not have permission to access this page.";
                if (Session["UserName"] == null) Server.Transfer("Login.aspx");
                Server.Transfer("Home.aspx");
            }
        }

        protected void btnRetrieve_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True");
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "Select * FROM [Incidents] WHERE Incident_Num='" + ListBox1.SelectedValue + "'";
            cmd.ExecuteNonQuery();
            SqlDataReader sdr = cmd.ExecuteReader();
            while(sdr.Read())
            {
                lblCustID.Text = sdr["Username"].ToString();
                lblDate.Text = sdr["Date_Time"].ToString();
                lblIncident.Text = sdr["Incident_Num"].ToString();
                lblStatus.Text = sdr["Status"].ToString();
                lblDesc.Text = sdr["Description"].ToString();
            }
            con.Close();
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Server.Transfer("Login.aspx");
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Server.Transfer("Home.aspx");
        }
    }
}