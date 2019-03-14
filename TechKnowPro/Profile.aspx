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
            width: 418px;
        }
        .auto-style7 {
            height: 23px;
        }
        .auto-style8 {
            width: 418px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        &nbsp;<table class="auto-style1">
            <tr>
                <td>
                    TechKnow Pro Incident Management Software
                </td>
                <td>
                    <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" />
                </td>
            </tr>
        </table>
        <div>
            <br/>
            <h3>Account Profile<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Secret_Question] FROM [User]">
                </asp:SqlDataSource>
            </h3>
            <table class="auto-style1">
                <tr>
                    <td colspan="2" class="auto-style7"><h4>User Information</h4></td>
                </tr>
                <tr>
                    <td class="auto-style8">*Username:</td>
                    <td>
                        <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionUsername" runat="server" ControlToValidate="txtUsername" ErrorMessage="Email address must be valid!" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">
                        <asp:Label ID="lblNewPass" runat="server" Text="New Password: " Visible="False"></asp:Label>
                    </td>
                    <td class="auto-style2">
                        <asp:TextBox ID="txtNewPass" runat="server" TextMode="Password" Visible="False" ></asp:TextBox>
                        <asp:RegularExpressionValidator ID="validateRegexPass" runat="server" ControlToValidate="txtNewPass" ErrorMessage="Password must be 6-12 characters in length, and must contain at least 1 uppercase letter and 1 special character!" ValidationExpression="^(?=.*[A-Z]+.*)(?=.*[^a-zA-Z0-9]+.*).{6,12}$" ForeColor="Red" Visible="False"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">
                        <asp:Label ID="lblConfirmPass" runat="server" Enabled="False" Text="Confirm Password:" Visible="False"></asp:Label>
                    </td>
                    <td class="auto-style2">
                        <asp:TextBox ID="txtConfirmPass" runat="server" TextMode="Password" Visible="False"></asp:TextBox>
                        <asp:CompareValidator ID="validateConfirm" runat="server" ControlToCompare="txtNewPass" ControlToValidate="txtConfirmPass" ErrorMessage="Passwords must match!" ForeColor="Red" Visible="False"></asp:CompareValidator>
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
                        <asp:TextBox ID="txtLastName" runat="server" style="height: 22px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">*Secret Question</td>
                    <td>
                        <asp:DropDownList ID="drpSecretQuestion" runat="server" Width="237px" OnSelectedIndexChanged="drpSecretQuestion_SelectedIndexChanged">
                            <asp:ListItem Value="What is your favourite color?">What is your favourite color?</asp:ListItem>
                            <asp:ListItem Value="What was the name of your first pet?">What was the name of your first pet?</asp:ListItem>
                            <asp:ListItem Value="What is your dream job?">What is your dream job?</asp:ListItem>
                            <asp:ListItem Value="Who was your childhood best friend?">Who was your childhood best friend?</asp:ListItem>
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
                    <td colspan="2">
                        <asp:Button ID="btnPassChange" runat="server" CausesValidation="False" OnClick="btnPassChange_Click" Text="Change Password" />
                        <asp:Button ID="btnClear" runat="server" OnClick="btnClear_Click" Text="Clear" />
                        <asp:Button ID="btnUpdate" runat="server" Text="Update Profile" OnClick="btnUpdate_Click" />
                        <br />
                        <asp:Label ID="lblUpdate" runat="server"></asp:Label>
                        <asp:CustomValidator ID="CustomValidatorMissingFields" runat="server" ForeColor="Red" OnServerValidate="CustomValidatorMissingFields_ServerValidate"></asp:CustomValidator>
                    </td>
                </tr>
            </table>
        </div>
    </form>
    
</body>
</html>
