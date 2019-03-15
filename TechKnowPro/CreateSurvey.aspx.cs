using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TechKnowPro
{
    public partial class CreateSurvey : System.Web.UI.Page
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

<<<<<<< HEAD
=======
            int survey_id = 1;
            
>>>>>>> 3992e36a43835cfb4b64257e222b0d4638d33328
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True");
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT * FROM [Surveys] WHERE Username = '" + Session["Username"].ToString() + "'";
            cmd.ExecuteNonQuery();
            SqlDataReader sdr = cmd.ExecuteReader();
<<<<<<< HEAD
=======
            while (sdr.Read())
            {
                survey_id++;
            }
            con.Close();
>>>>>>> 3992e36a43835cfb4b64257e222b0d4638d33328

            if (sdr.Read())
            {
                lblCustomerID.Text = sdr["Username"].ToString();
            }
            
            con.Close();
        }
        
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                int surveynum = 1;

                SqlConnection con2 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True");
                con2.Open();
                SqlCommand cmd2 = con2.CreateCommand();
                cmd2.CommandType = System.Data.CommandType.Text;
                cmd2.CommandText = "select survey_num from Surveys";
                cmd2.ExecuteNonQuery();
                SqlDataReader sdr = cmd2.ExecuteReader();
                //retrieves the highest incident number and increments by 1 for the next number
                //returns empty if no items in table, case already handled above
                while (sdr.Read())
                    surveynum = (1 + Convert.ToInt32(sdr["survey_num"]));
                con2.Close();
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True");
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = System.Data.CommandType.Text;

<<<<<<< HEAD
                /*cmd.CommandText = "UPDATE [Surveys] SET " +
                    "  response_time = '" + radListResponse.SelectedValue + 
                    "' technician_efficiency = '" + radListTech.SelectedValue +
                    "' problem_resolution = '" + radListResolution.SelectedValue +
                    "' additional_comments = '" + txtAddComments.Text +
                    "' WHERE username ='" + Session["Username"].ToString() + "'";*/

                //cmd.CommandText = "insert into [Surveys](survey_num,username,incident_id, response_time,technician_efficiency, problem_resolution, additional_comments) values ('"+ surveynum + "','" + Session["Username"].ToString() +"','" + Convert.ToInt32(listIncidents.SelectedValue)  + "','" + radListResponse.SelectedValue + "','" + radListTech.SelectedValue + "','" + radListResolution.SelectedValue + "','" + txtAddComments.Text+"')";
                cmd.CommandText = "insert into [Surveys](survey_num, username, incident_id, response_time, technician_efficiency, problem_resolution, additional_comments) values ('" + surveynum + "','" + Session["Username"].ToString() + "','" + Convert.ToInt32(listIncidents.SelectedValue) + "','" + radListResponse.SelectedValue + "','" + radListTech.SelectedValue + "','" + radListResolution.SelectedValue + "','" + txtAddComments.Text + "')";
                cmd.ExecuteNonQuery();
                if (chkContact.Checked == true)
=======
                cmd.CommandText = "INSERT INTO [Surveys] SET " +

                    "'  response_time = '" + radListResponse.SelectedValue + 

                    "' technician_efficiency = '" + radListTech.SelectedValue +
                    "' problem_resolution = '" + radListResolution.SelectedValue +
                    "' additional_comments = '" + txtAddComments.Text +
                    "' WHERE username ='" + Session["Username"].ToString() + "'";

                if(chkContact.Checked == true)
>>>>>>> 3992e36a43835cfb4b64257e222b0d4638d33328
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
<<<<<<< HEAD
=======
            surv
>>>>>>> 3992e36a43835cfb4b64257e222b0d4638d33328
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login.aspx");
            Session.Abandon();
        }
    }
}