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
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            if(Session["User Type"] == null || Session["User Type"].ToString() != "tech")
            {
                Session["ErrorMessage"] = "You do not have permission to access this page.";
                if(Session["UserName"] == null) Response.Redirect("Login.aspx");
                Response.Redirect("Home.aspx");
            }
            //In case this is the first incident going into the table
            lblIncidentNum.Text = "1";
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True");
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select Incident_Num from Incidents";
            cmd.ExecuteNonQuery();
            SqlDataReader sdr = cmd.ExecuteReader();
            //retrieves the highest incident number and increments by 1 for the next number
            //returns empty if no items in table, case already handled above
            while (sdr.Read())
                lblIncidentNum.Text = (1+Convert.ToInt32(sdr["Incident_Num"])).ToString();
            lblDate.Text = DateTime.Now.ToString();
            con.Close();
            if(Session["Success"] == null)
            {
                lblSuccess.Visible = false;
            }
            else
            {
                lblSuccess.Visible = true;
                Session["Success"] = null;
            }
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

        protected void custValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if(Session["Success"].ToString() == "true")
            {
                Session["Success"] = "false";
            }

        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtCustId.Text != null)
            {
                Incident newIncident = new Incident(Convert.ToInt32(lblIncidentNum.Text), txtCustId.Text, lblDate.Text, DropDownList2.SelectedValue.ToString(), txtDescription.Text, RadioButtonList1.SelectedValue.ToString());
                newIncident.addIncidenttoDatabase();
                Session["Success"] = "true";
                Response.Redirect("CreateIncident.aspx");
            }
            else
            {

            }
        }

        protected void FormView1_DataBound(object sender, EventArgs e)
        {
            FormView FormView1 = sender as FormView;
            if(FormView1.SelectedValue != null) txtCustId.Text = FormView1.SelectedValue.ToString();
            FormView1.Visible = false;
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Session["Success"] = "false";
            Response.Redirect("Home.aspx");
        }
    }
}