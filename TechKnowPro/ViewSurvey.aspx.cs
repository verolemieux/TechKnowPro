using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace TechKnowPro
{
    public partial class ViewSurvey : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            if (Session["User Type"] == null) {
                Session["ErrorMessage"] = "You do not have permission to access this page.";
                Response.Redirect("Login.aspx");
                 
            }
            else if (Session["User Type"].ToString() != "admin")
            {
                Session["ErrorMessage"] = "You do not have permission to access this page.";
                Response.Redirect("Home.aspx");
            }

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True");
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT * FROM [User] where not Username='tech@isp.net' AND not Username='admin@isp.net'";
            cmd.ExecuteNonQuery();
            SqlDataReader sdr = cmd.ExecuteReader();
          
            con.Close();
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            

            if(DropDownList1.SelectedValue=="choose a customer")
            {
                surveyInfo.Visible = false;
                selectCustomerPanel.Visible = false;
                return;
            }

            surveyInfo.Visible = false;
            selectCustomerPanel.Visible = true;

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True");
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT * FROM [User] WHERE Username='" + DropDownList1.SelectedValue.ToString() + "'";
            cmd.ExecuteNonQuery();
            SqlDataReader sdr = cmd.ExecuteReader();
          
            con.Close();

            ListBox1.Items.Clear();
            con.Open();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "Select incident_id FROM [Surveys] WHERE Username='" + DropDownList1.SelectedValue + "'";
            cmd.ExecuteNonQuery();
             sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    ListItem surveyItem = new ListItem();
                    surveyItem.Text = "Select the survey for incident number: " + sdr["incident_id"].ToString();
                    surveyItem.Value = sdr["incident_id"].ToString();
                    ListBox1.Items.Add(surveyItem);
                }
            }
            else
            {
                ListItem surveyItem = new ListItem();
                surveyItem.Text = "This user does not have a survey on file";
                surveyItem.Value = "";
                ListBox1.Items.Add(surveyItem);
            }
            con.Close();
        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

       

        protected void retrieveSurveyInformation(object sender, EventArgs e)
        {

        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

            if (ListBox1.SelectedValue == "")
            {
                return;
            }

            surveyInfo.Visible = true;
            selectCustomerPanel.Visible = true;

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True");
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT * FROM [Surveys] WHERE Username='" + DropDownList1.SelectedValue.ToString() + "' AND incident_id = '" + ListBox1.SelectedValue.ToString() + "'";
            cmd.ExecuteNonQuery();
            SqlDataReader sdr = cmd.ExecuteReader();
            

            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    lblAdditionalInfo.Text = (sdr["additional_comments"].ToString() == "" ? " N/A" : sdr["additional_comments"].ToString());
                    lblContactMethod.Text = (sdr["contact_preference"].ToString() == "" ? " N/A" : sdr["contact_preference"].ToString());
                    lblRequestContact.Text = (sdr["contact_further"].ToString() == "" ? " N/A" : sdr["contact_further"].ToString());
                    lblProblemResolution.Text = (sdr["problem_resolution"].ToString() == "" ? " N/A" : sdr["problem_resolution"].ToString());
                    lblTechEfficiency.Text = (sdr["technician_efficiency"].ToString() == "" ? " N/A" : sdr["technician_efficiency"].ToString());
                    lblResponseTime.Text = (sdr["response_time"].ToString() == "" ? " N/A" : sdr["response_time"].ToString());

                }
            }

            con.Close();

        }
    }
}