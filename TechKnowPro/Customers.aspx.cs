using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace TechKnowPro
{
    public partial class Customers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            if (Session["User Type"] == null || (Session["User Type"].ToString() != "tech" && Session["User Type"].ToString() != "admin"))
            {
                Session["ErrorMessage"] = "You do not have permission to access this page.";
                if (Session["UserName"] == null) Server.Transfer("Login.aspx");
                Server.Transfer("Home.aspx");
            }
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True");
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT * FROM [User] where not Username='tech@isp.net' AND not Username='admin@isp.net'";
            cmd.ExecuteNonQuery();
            SqlDataReader sdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            if (dt.Rows[0] != null)
            {
                lblAddress.Text = dt.Rows[0]["Address"].ToString();
                lblEmail.Text = dt.Rows[0]["Username"].ToString();
                lblPhone.Text = "555-555-5555";
            }
            con.Close();
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True");
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT * FROM [User] WHERE Username='" + DropDownList1.SelectedValue.ToString() + "'";
            cmd.ExecuteNonQuery();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                lblAddress.Text = sdr["Address"].ToString();
                lblEmail.Text = sdr["Username"].ToString();
                lblPhone.Text = sdr["Phone_Number"].ToString();
            }
            con.Close();
        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Server.Transfer("Login.aspx");
        }
    }
}