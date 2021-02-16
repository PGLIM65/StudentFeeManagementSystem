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
    public partial class AdminPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButSubmit_Click(object sender, EventArgs e)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery = "select * from " + DropDownList1.SelectedItem.Text;
            sqlconn.Open();
            SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
            SqlDataAdapter sda = new SqlDataAdapter(sqlcomm);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            
            if(DropDownList1.SelectedItem.Text == "CourseTable")
            {
                GdCourse.Visible = true;
                GdStudent.Visible = false;
                GdTutor.Visible = false;
                GdCourse.DataSource = dt;
                GdCourse.DataBind();
            }
            else if(DropDownList1.SelectedItem.Text == "student")
            {
                GdCourse.Visible = false;
                GdStudent.Visible = true;
                GdTutor.Visible = false;
                GdStudent.DataSource = dt;
                GdStudent.DataBind();
            }
            else
            {
                GdCourse.Visible = false;
                GdStudent.Visible = false;
                GdTutor.Visible = true;
                GdTutor.DataSource = dt;
                GdTutor.DataBind();
            }

            sqlconn.Close();
        }

        protected void GdCourse_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GdCourse.EditIndex = -1;
        }

        protected void GdCourse_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GdCourse.Rows[e.RowIndex];

            int courseid = Convert.ToInt32(GdCourse.DataKeys[e.RowIndex].Values[0]);
            string cname = (row.Cells[2].Controls[0] as TextBox).Text;
            string duration = (row.Cells[3].Controls[0] as TextBox).Text;
            string fees = (row.Cells[4].Controls[0] as TextBox).Text;

            string mainconn = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery = "update CourseTable set Cname=@Cname,Duration=@Duration,Cfees=@Cfees where Cid=@Cid";
            sqlconn.Open();
            SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
            sqlcomm.Parameters.AddWithValue("@Cid", courseid);
            sqlcomm.Parameters.AddWithValue("@Cname", cname);
            sqlcomm.Parameters.AddWithValue("@Duration", duration);
            sqlcomm.Parameters.AddWithValue("@Cfees", fees);
            sqlcomm.ExecuteNonQuery();
            sqlconn.Close();
        }

        protected void GdCourse_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GdCourse.EditIndex = e.NewEditIndex;
        }

        protected void GdCourse_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int courseid = Convert.ToInt32(GdCourse.DataKeys[e.RowIndex].Values[0]);

            string mainconn = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery = "delete from CourseTable where Cid=@Cid";
            sqlconn.Open();
            SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
            sqlcomm.Parameters.AddWithValue("@Cid", courseid);
            sqlcomm.ExecuteNonQuery();
            sqlconn.Close();
        }

        protected void GdStudent_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GdStudent.EditIndex = -1;
        }

        protected void GdStudent_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GdStudent.Rows[e.RowIndex];

            int Stid = Convert.ToInt32(GdStudent.DataKeys[e.RowIndex].Values[0]);
            string Stfname = (row.Cells[2].Controls[0] as TextBox).Text;
            string Stlname = (row.Cells[3].Controls[0] as TextBox).Text;
            string StFatherName = (row.Cells[4].Controls[0] as TextBox).Text;
            string StFatherPhone = (row.Cells[5].Controls[0] as TextBox).Text;
            string StEmail = (row.Cells[6].Controls[0] as TextBox).Text;
            string StPhone = (row.Cells[7].Controls[0] as TextBox).Text;
            string CourseJoin = (row.Cells[8].Controls[0] as TextBox).Text;
            string CourseFees = (row.Cells[9].Controls[0] as TextBox).Text;
            string FirstInstallment = (row.Cells[10].Controls[0] as TextBox).Text;
            string FeesDue = (row.Cells[11].Controls[0] as TextBox).Text;

            string mainconn = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery = "update student set Stfname=@Stfname,Stlname=@Stlname,StFatherName=@StFatherName,StFatherPhone=@StFatherPhone,StEmail=@StEmail,StPhone=@StPhone,CourseJoin=@CourseJoin,CourseFees=@CourseFees,FirstInstallment=@FirstInstallment,FeesDue=@FeesDue where Stid=@Stid";
            sqlconn.Open();
            SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
            sqlcomm.Parameters.AddWithValue("@Stid", Stid);
            sqlcomm.Parameters.AddWithValue("@Stfname", Stfname);
            sqlcomm.Parameters.AddWithValue("@Stlname", Stlname);
            sqlcomm.Parameters.AddWithValue("@StFatherName", StFatherName);
            sqlcomm.Parameters.AddWithValue("@StFatherPhone", StFatherPhone);
            sqlcomm.Parameters.AddWithValue("@StEmail", StEmail);
            sqlcomm.Parameters.AddWithValue("@StPhone", StPhone);
            sqlcomm.Parameters.AddWithValue("@CourseJoin", CourseJoin);
            sqlcomm.Parameters.AddWithValue("@CourseFees", CourseFees);
            sqlcomm.Parameters.AddWithValue("@FirstInstallment", FirstInstallment);
            sqlcomm.Parameters.AddWithValue("@FeesDue", FeesDue);
            sqlcomm.ExecuteNonQuery();
            sqlconn.Close();
        }

        protected void GdStudent_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GdStudent.EditIndex = e.NewEditIndex;
        }

        protected void GdStudent_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int Stid = Convert.ToInt32(GdStudent.DataKeys[e.RowIndex].Values[0]);

            string mainconn = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery = "delete from student where Stid=@Stid";
            sqlconn.Open();
            SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
            sqlcomm.Parameters.AddWithValue("@Stid", Stid);
            sqlcomm.ExecuteNonQuery();
            sqlconn.Close();
        }

        protected void GdTutor_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GdTutor.EditIndex = -1;
        }

        protected void GdTutor_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GdTutor.Rows[e.RowIndex];

            int Tid = Convert.ToInt32(GdTutor.DataKeys[e.RowIndex].Values[0]);
            string Tname = (row.Cells[2].Controls[0] as TextBox).Text;
            string Temail = (row.Cells[3].Controls[0] as TextBox).Text;
            string Tphone = (row.Cells[4].Controls[0] as TextBox).Text;
            string Tcourse = (row.Cells[5].Controls[0] as TextBox).Text;
            string Tqualification = (row.Cells[6].Controls[0] as TextBox).Text;

            string mainconn = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery = "update tutor set Tname=@Tname,Temail=@Temail,Tphone=@Tphone,Tcourse=@Tcourse,Tqualification=@Tqualification where Tid=@Tid";
            sqlconn.Open();
            SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
            sqlcomm.Parameters.AddWithValue("@Tid", Tid);
            sqlcomm.Parameters.AddWithValue("@Tname", Tname);
            sqlcomm.Parameters.AddWithValue("@Temail", Temail);
            sqlcomm.Parameters.AddWithValue("@Tphone", Tphone);
            sqlcomm.Parameters.AddWithValue("@Tcourse", Tcourse);
            sqlcomm.Parameters.AddWithValue("@Tqualification", Tqualification);
            sqlcomm.ExecuteNonQuery();
            sqlconn.Close();
        }

        protected void GdTutor_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GdTutor.EditIndex = e.NewEditIndex;
        }

        protected void GdTutor_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int Tid = Convert.ToInt32(GdTutor.DataKeys[e.RowIndex].Values[0]);

            string mainconn = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery = "delete from tutor where Tid=@Tid";
            sqlconn.Open();
            SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
            sqlcomm.Parameters.AddWithValue("@Tid", Tid);
            sqlcomm.ExecuteNonQuery();
            sqlconn.Close();
        }
    }
}