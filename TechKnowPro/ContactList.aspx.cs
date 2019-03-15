using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace TechKnowPro
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
                
                Console.WriteLine(ListBox1.SelectedValue);
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

        protected void emptyList(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True");

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "Update [User] set Require_Contact='false' where Require_Contact='true'";
            cmd.ExecuteNonQuery();
            con.Close();
            ListBox1.DataBind();
        }

        protected void removeContact(object sender, EventArgs e)
        {

            String selected_user_name = ListBox1.SelectedValue;
            if (selected_user_name == null) selected_user_name = "";
            
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True");
            
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "Update [User] set Require_Contact='false' where Username='" + ListBox1.SelectedValue.ToString() + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            ListBox1.DataBind();
        }

        protected void selectAdditionalCustomers(object sender, EventArgs e)
        {
            Response.Redirect("Customers.aspx");
        }

        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }
    }
}