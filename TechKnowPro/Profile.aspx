<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="TechKnowPro.Profile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 26px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table class="auto-style1">
            <tr>
                <td>
                    TechKnow Pro Incident Management Software
                </td>
                <td>
                    <asp:Button ID="btnLogout" runat="server" Text="Logout" />
                </td>
            </tr>
        </table>
        <div>
            <br/>
            <h3>Account Profile<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [User]"></asp:SqlDataSource>
            </h3>
            <table class="auto-style1">
                <tr>
                    <td colspan="2"><h4>User Information</h4></td>
                </tr>
                <tr>
                    <td>Profile Name:</td>
                    <td>
                        <asp:TextBox ID="txtProfileName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>*Username:</td>
                    <td>
                        <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">*Password:</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>            
        </div>
        <br />
        <div>
            <table class="auto-style1">
                <tr>
                    <td colspan="2"><h4>Contact Information</h4></td>
                </tr>
                <tr>
                    <td>*First Name:</td>
                    <td>
                        <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>*Last Name:</td>
                    <td>
                        <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>*Address:</td>
                    <td>
                        <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>*Email:</td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnUpdate" runat="server" Text="Update Profile" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
    
</body>
</html>
