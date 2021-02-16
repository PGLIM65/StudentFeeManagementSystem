<%@ Page Title="" Language="C#" MasterPageFile="~/SMS.Master" AutoEventWireup="true" CodeBehind="StudentPage.aspx.cs" Inherits="Student_Management_System.StudentPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>This is the Student's Fee Management Page!</h1>
    <div style="background-color:wheat; width: 310px; height: 335px;">
        <table border="1">
            <tr>
                <td>First Name</td>
                <td>
                    <asp:TextBox ID="TxtStFname" runat="server"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td>Last Name</td>
                <td>
                    <asp:TextBox ID="TxtStLname" runat="server"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td>Father's Name</td>
                <td>
                    <asp:TextBox ID="TxtFatherName" runat="server"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td>Father's Contact</td>
                <td>
                    <asp:TextBox ID="TxtFatherPhone" runat="server"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td>Email</td>
                <td>
                    <asp:TextBox ID="TxtStEmail" runat="server"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td>Contact</td>
                <td>
                    <asp:TextBox ID="TxtPhone" runat="server"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td>Course</td>
                <td>
                    <asp:DropDownList ID="DDLCourseName" runat="server" AutoPostBack="true" AppendDataBoundItems="true" DataSourceID="SqlDataSource1" DataTextField="Cname" DataValueField="Cname" Height="16px" Width="179px" OnSelectedIndexChanged="DDLCourseName_SelectedIndexChanged">
                        <asp:ListItem Value="0" Text="-- SELECT COURSE --"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:StudentManagementSystemConnectionString2 %>" SelectCommand="SELECT [Cname] FROM [CourseTable]"></asp:SqlDataSource>
                </td>
            </tr>

            <tr>
                <td>Course Fees</td>
                <td>
                    <asp:Label ID="LabCourseFees" runat="server" Text=""></asp:Label>
                </td>
            </tr>

            <tr>
                <td>Installment</td>
                <td>
                    <asp:TextBox ID="TxtCourseInstallment" runat="server" AutoPostBack="true" OnTextChanged="TxtCourseInstallment_TextChanged"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td>Fees Due</td>
                <td>
                    <asp:Label ID="LabDueFees" runat="server" Text=""></asp:Label>
                </td>
            </tr>

            <tr>
                <td>Join Date</td>
                <td>
                    <asp:Literal ID="LitJoinDate" runat="server"></asp:Literal>
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Button ID="ButStudent" runat="server" Text="Insert Record" OnClick="ButStudent_Click" />
                </td>
                <td>
                    <asp:Label ID="Labmsg" runat="server" Text="" ForeColor="Green"></asp:Label>
                </td>
            </tr>

        </table>
    </div>
    <div>

    </div>
    <div>

    </div>

    <div style="background-image: url('Images/student-management.jpg'); " class="auto-style1"></div>
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style1 {
            height: 300px;
        }
    </style>
</asp:Content>

