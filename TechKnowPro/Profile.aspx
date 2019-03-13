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
        .auto-style3 {
            width: 416px;
        }
        .auto-style5 {
            height: 26px;
            width: 413px;
        }
        .auto-style6 {
            width: 413px;
        }
        .auto-style7 {
            height: 23px;
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
                    <td colspan="2" class="auto-style7"><h4>User Information</h4></td>
                </tr>
                <tr>
                    <td class="auto-style6">*Username:</td>
                    <td>
                        <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">New Password:</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="txtNewPassword" runat="server" OnTextChanged="txtPassword_TextChanged" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">Confirm New Password:</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="txtConfirmPassword" runat="server" Visible="False"></asp:TextBox>
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
                    <td class="auto-style3">*First Name:</td>
                    <td>
                        <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">*Last Name:</td>
                    <td>
                        <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">*Secret Question</td>
                    <td>
                        <asp:DropDownList ID="drpSecretQuestion" runat="server" Width="215px">
                            <asp:ListItem Value="0">What is your favourite colour?</asp:ListItem>
                            <asp:ListItem Value="1">What is your favourite book?</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">*Secret Answer</td>
                    <td>
                        <asp:TextBox ID="txtSecretAnswer" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">*Address:</td>
                    <td>
                        <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">*Email:</td>
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
