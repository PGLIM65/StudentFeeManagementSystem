using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Student_Management_System
{
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButLogin_Click(object sender, EventArgs e)
        {
            if (TxtAdminId.Text == "Admin" && TxtPwdAdmin.Text == "Admin" || TxtAdminId.Text == "PhilippeLim" && 
                TxtPwdAdmin.Text == "PhilippeLim" || TxtAdminId.Text == "Maria" && TxtPwdAdmin.Text == "Maria" ||
                TxtAdminId.Text == "EmmanuelArturo" && TxtPwdAdmin.Text == "EmmanuelArturo" || TxtAdminId.Text == "Fritz" && 
                TxtPwdAdmin.Text == "Fritz")
            {
                Session["Adminname"] = "Welcome " + TxtAdminId.Text;
                Response.Redirect("AdminPage.aspx");
            }
            else
            {
                Labmsg.Text = "Failed Login Details";
            }
        }

        protected void ButExit_Click(object sender, EventArgs e)
        {
            TxtAdminId.Text = "";
            TxtPwdAdmin.Text = "";
        }
    }
}