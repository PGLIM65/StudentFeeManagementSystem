using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace Student_Management_System
{
    public partial class CoursePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButCourse_Click(object sender, EventArgs e)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery = "Insert into [dbo].[CourseTable] (Cname,Duration,Cfees) values (@Cname,@Duration,@Cfees)";
            SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
            sqlconn.Open();
            sqlcomm.Parameters.AddWithValue("@Cname", TxtCoursename.Text);
            sqlcomm.Parameters.AddWithValue("@Duration", TxtDuration.Text);
            sqlcomm.Parameters.AddWithValue("@Cfees", TxtFees.Text);
            sqlcomm.ExecuteNonQuery();
            LabMsg.Text = "The Course " + TxtCoursename.Text + " Is Saved Successfully!";
            TxtCoursename.Text = "";
            TxtDuration.Text = "";
            TxtFees.Text = "";
            sqlconn.Close();
        }
    }
}