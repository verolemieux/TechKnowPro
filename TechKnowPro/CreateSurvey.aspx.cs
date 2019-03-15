using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TechKnowPro
{
    public partial class Surveys : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            if (Session["User Type"] == null || Session["User Type"].ToString() != "customer")
            {
                Session["ErrorMessage"] = "You do not have permission to access this page.";
                if (Session["Username"] == null) Response.Redirect("Login.aspx");
                Response.Redirect("Home.aspx");
            }

            int survey_id = 1;
            
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True");
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT survey_id FROM [Survey]";
            cmd.ExecuteNonQuery();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                survey_id++;
            }
            con.Close();

             /*
            if (!IsPostBack)
            {
                if (sdr.Read())
                {
                    lblUsername.Text = sdr["Username"].ToString();
                }
            }
            
            con.Close();
            */
        }
        
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True");
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.CommandText = "INSERT INTO [Surveys] SET " +

                    "'  response_time = '" + radListResponse.SelectedValue + 

                    "' technician_efficiency = '" + radListTech.SelectedValue +
                    "' problem_resolution = '" + radListResolution.SelectedValue +
                    "' additional_comments = '" + txtAddComments.Text +
                    "' WHERE username ='" + Session["Username"].ToString() + "'";

                if(chkContact.Checked == true)
                {
                    validatorContact.Visible = true;                   
                    radListContact.Visible = true;
                    radListContact.CausesValidation = true;
                    cmd.CommandText = "UPDATE [Surveys] " +
                        "SET contact_further ='" + 1 + 
                        "' contact_preference = '" + radListContact.SelectedValue +
                        "' WHERE username ='" + Session["Username"].ToString() + "'";
                    con.Close();
                }
                else
                {
                    validatorContact.Visible = false;
                    cmd.CommandText = "UPDATE [Surveys] SET contact_further ='" + 0 + "'WHERE username = '" + Session["Username"].ToString() + "'";
                    con.Close();

                }                
                con.Close();

            }
            surv
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login.aspx");
            Session.Abandon();
        }
    }
}