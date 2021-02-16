<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="Student_Management_System.HomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Page</title>

</head>
<body style="height: 815px">
    <form id="form1" runat="server">
        <div style="background-image:url('Images/Login.jpg'); height: 815px;">
            <table align="center">
                <tr>
                    <td colspan="2" align="center">
                        <h1>Student Administration System</h1>
                        <h2>ASP.NET C# Application</h2>
                    </td>
                    
                </tr>


                <tr>
                    <td align="center">
                        <b>Username: </b>
                    </td>
                    <td align="center">
                        <asp:TextBox ID="TxtAdminId" runat="server" Height="32px" Width="317px"></asp:TextBox>
                    </td>
                </tr>


                <tr>
                    <td align="center">
                        <b>Password: </b>
                    </td>
                    <td align="center">
                        <asp:TextBox ID="TxtPwdAdmin" runat="server" Height="32px" Width="317px" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>


                <tr>
                    <td align="center" colspan="2">
                        <asp:Button ID="ButLogin" runat="server" Text="Login" Font-Bold="True" Font-Italic="True" Height="43px" Width="179px" BackColor="#00cc00" BorderColor="Black" BorderStyle="Inset" OnClick="ButLogin_Click" />
                        <asp:Button ID="ButExit" runat="server" Text="Clear" BackColor="#CCCC00" BorderColor="Black" BorderStyle="Dashed" Height="47px" Width="94px" OnClick="ButExit_Click" />
                    </td>
                    
                </tr>


                <tr>
                    <td colspan="2" align="center">
                        <asp:Label ID="Labmsg" runat="server" Text="" ForeColor="Red"></asp:Label>
                    </td>
                    
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
