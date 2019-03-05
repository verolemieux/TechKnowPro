using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


namespace TechKnowPro
{
    public partial class CreateIncident : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["UserType"] == null || Session["UserType"].ToString() != "tech")
            {
                Session["ErrorMessage"] = "You do not have permission to access this page.";
                if(Session["UserName"] == null) Response.Redirect("Login.aspx");
                Response.Redirect("Home.aspx");
            }
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True");
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select Incident_Num from Incidents";
            cmd.ExecuteNonQuery();
            SqlDataReader sdr = cmd.ExecuteReader();
            //retrieves the highest incident number and increments by 1 for the next number
            while (sdr.Read())
                lblIncidentNum.Text = (1+Convert.ToInt32(sdr["Incident_Num"])).ToString();
            lblDate.Text = DateTime.Now.ToString();
        }

        protected void DropDownList1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True");
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select [Username] from [User]" + " where Username='" + DropDownList1.SelectedValue + "'";
            cmd.ExecuteNonQuery();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
                txtCustId.Text = sdr["Username"].ToString();
        }
    }
}