using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Student_Management_System
{
    public partial class TutorPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LitJoinDate.Text = DateTime.Now.ToString();
        }

        protected void ButTutor_Click(object sender, EventArgs e)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery = "Insert into [dbo].[tutor] (Tname,Temail,Tphone,Tcourse,Tqualification,JoinDate) values (@Tname,@Temail,@Tphone,@Tcourse,@Tqualification,@JoinDate)";
            SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
            sqlconn.Open();
            sqlcomm.Parameters.AddWithValue("@Tname", TxtTutorName.Text);
            sqlcomm.Parameters.AddWithValue("@Temail", TxtEmail.Text);
            sqlcomm.Parameters.AddWithValue("@Tphone", TxtPhone.Text);
            sqlcomm.Parameters.AddWithValue("@Tcourse", DDLCourse.SelectedItem.Text);
            sqlcomm.Parameters.AddWithValue("@Tqualification", TxtQualification.Text);
            sqlcomm.Parameters.AddWithValue("@JoinDate", LitJoinDate.Text);
            sqlcomm.ExecuteNonQuery();
            Labmsg.Text = "The Tutor " + TxtTutorName.Text + " Is Saved Successfully!";
            TxtTutorName.Text = "";
            TxtEmail.Text = "";
            TxtPhone.Text = "";
            TxtQualification.Text = "";
            sqlconn.Close();
        }
    }
}