<%@ Page Title="" Language="C#" MasterPageFile="~/SMS.Master" AutoEventWireup="true" CodeBehind="TutorPage.aspx.cs" Inherits="Student_Management_System.TutorPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>This is the Tutor Page!</h1>
    <div style="background-color:cadetblue; width: 295px; height: 200px;">
        <table border="1">
            <tr>
            <td>Tutor Name</td>
            <td>
                <asp:TextBox ID="TxtTutorName" runat="server"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>Email</td>
            <td>
                <asp:TextBox ID="TxtEmail" runat="server"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>Phone Number</td>
            <td>
                <asp:TextBox ID="TxtPhone" runat="server"></asp:TextBox>
            </td>
        </tr>
        
        <tr>
            <td>Course</td>
            <td>
                <asp:DropDownList ID="DDLCourse" runat="server" Height="19px" Width="195px" DataSourceID="SqlDataSource1" AppendDataBoundItems="true" DataTextField="Cname" DataValueField="Cname">
                    <asp:ListItem Value="0" Text="-- SELECT COURSE --"></asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:StudentManagementSystemConnectionString %>" SelectCommand="SELECT [Cname] FROM [CourseTable]"></asp:SqlDataSource>
            </td>
        </tr>

        <tr>
            <td>Qualification</td>
            <td>
                <asp:TextBox ID="TxtQualification" runat="server"></asp:TextBox>
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
                <asp:Button ID="ButTutor" runat="server" Text="Insert" OnClick="ButTutor_Click" />
            </td>
            <td>
                <asp:Label ID="Labmsg" runat="server" Text="" ForeColor="Green"></asp:Label>
            </td>
        </tr>

        </table>
    </div>

    <div style="background-image: url('Images/student-management.jpg'); height:300px;"></div>
</asp:Content>



