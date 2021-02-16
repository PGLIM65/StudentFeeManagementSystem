using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Net;
using System.Net.Mail;

namespace Student_Management_System
{
    public partial class StudentPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LitJoinDate.Text = DateTime.Now.ToString();
        }

        protected void ButStudent_Click(object sender, EventArgs e)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery = "Insert into [dbo].[student] (Stfname,Stlname,StFatherName,StFatherPhone,StEmail,StPhone,CourseJoin,CourseFees,FirstInstallment,FeesDue,JoinDate) values(@Stfname,@Stlname,@StFatherName,@StFatherPhone,@StEmail,@StPhone,@CourseJoin,@CourseFees,@FirstInstallment,@FeesDue,@JoinDate)";
            sqlconn.Open();
            SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
            sqlcomm.Parameters.AddWithValue("@Stfname", TxtStFname.Text);
            sqlcomm.Parameters.AddWithValue("@Stlname", TxtStLname.Text);
            sqlcomm.Parameters.AddWithValue("@StFatherName", TxtFatherName.Text);
            sqlcomm.Parameters.AddWithValue("@StFatherPhone", TxtFatherPhone.Text);
            sqlcomm.Parameters.AddWithValue("@StEmail", TxtStEmail.Text);
            sqlcomm.Parameters.AddWithValue("@StPhone", TxtPhone.Text);
            sqlcomm.Parameters.AddWithValue("@CourseJoin", DDLCourseName.SelectedItem.Text);
            sqlcomm.Parameters.AddWithValue("@CourseFees", LabCourseFees.Text);
            sqlcomm.Parameters.AddWithValue("@FirstInstallment", TxtCourseInstallment.Text);
            sqlcomm.Parameters.AddWithValue("@FeesDue", LabDueFees.Text);
            sqlcomm.Parameters.AddWithValue("@JoinDate", LitJoinDate.Text);
            sqlcomm.ExecuteNonQuery();
            Labmsg.Text = "The Student " + TxtStFname.Text + " Is Saved Successfully.. <br/> The Fee Receipt has been sent to your email" + TxtStEmail.Text;

            MailMessage mm = new MailMessage("philippelim65@gmail.com", TxtStEmail.Text);
            mm.Subject = "Your Receipt Details...";
            mm.Body = "Good Day " + TxtStFname.Text + ", <br/> Your Installment Fee has been processed and these are the following details: <br/><br/>" + "Student's Name: " + TxtStFname.Text + " " + TxtStLname.Text + "<br/>Student's Contact: " + TxtPhone.Text + "<br/>Course Selected: " + DDLCourseName.SelectedItem.Text + "<br/>Course Fee: ₱" + LabCourseFees.Text + "<br/>Installment Paid: ₱" + TxtCourseInstallment.Text + "<br/>Student's Remaining Balance: ₱" + LabDueFees.Text + "<br/><br/><h1 style='color:red'>Note: All Remaining Balance Fee Should Be Settled Before The End Of The Term, In Order to have a FINAL GRADE for the course...</h1>" + "<br/><br/>---<h3>Thank You<br/>Yours Truly, PGDL</h3>";
            mm.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            
            NetworkCredential nc = new NetworkCredential("philippelim65@gmail.com", "svnmybdrkcuzkpgp");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = nc;
            smtp.Send(mm);
            
            sqlconn.Close();
        }

        protected void DDLCourseName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery1 = "select * from [dbo].[CourseTable] where Cname=@Cname";
            sqlconn.Open();
            SqlCommand sqlcomm1 = new SqlCommand(sqlquery1, sqlconn);
            sqlcomm1.Parameters.AddWithValue("@Cname", DDLCourseName.SelectedItem.Text);
            SqlDataReader sdr1 = sqlcomm1.ExecuteReader();
            while(sdr1.Read())
            {
                LabCourseFees.Text = sdr1["Cfees"].ToString();
            }
            sqlconn.Close();
        }

        protected void TxtCourseInstallment_TextChanged(object sender, EventArgs e)
        {
            int balance = Convert.ToInt32(LabCourseFees.Text) - Convert.ToInt32(TxtCourseInstallment.Text);
            LabDueFees.Text = balance.ToString();
        }
    }
}