<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="TechKnowPro.ForgotPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid centered" style="margin: 0 auto; text-align:center">
            <h1 style="margin:5px">FORGOT PASSWORD</h1>
            <asp:Label ID="lblChangePasswordErr" style="margin:5px" runat="server"></asp:Label>
            <div class="form-group col-md-4" style="margin:auto; left: 0px; top: 0px;">
                <div class="col" style="margin:5px">
                    <asp:Label ID="lblUsername" runat="server" Text="Username"></asp:Label>
                    <asp:TextBox ID="txtUsername" class="form-control" runat="server"></asp:TextBox>
                </div>
                 <div class="col" style="margin:5px">
                    <asp:Label ID="lblPostalCode" runat="server" Text="Postal Code"></asp:Label>
                    <asp:TextBox ID="txtPostalCode" runat="server" class="form-control"></asp:TextBox>
                </div>
                <div class="col" style="margin:5px">
                    <asp:Label ID="lblSecretQuestion" runat="server" Text="Secret Question"></asp:Label>
                    <asp:DropDownList ID="DropDownListSecretQuestion" class=" form-control" runat="server">
                        <asp:ListItem Value="1">What is your favorite color?</asp:ListItem>
                        <asp:ListItem Value="2">What was the name of your first pet?</asp:ListItem>
                        <asp:ListItem Value="1">What is your dream job?</asp:ListItem>
                        <asp:ListItem Value="4">Who was your childhood best friend?</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col" style="margin:5px">
                    <asp:Label ID="lblSecretAnswer" runat="server" Text="Secret Answer"></asp:Label>
                    <asp:TextBox ID="txtSecretAnswer" runat="server" class="form-control"></asp:TextBox>
                </div>
                 <div class="col" style="margin:5px">
                    <asp:Label ID="lblNewPassword" runat="server" Text="New Password"></asp:Label>
                    <asp:TextBox ID="txtNewPassword" runat="server" class="form-control"></asp:TextBox>
                </div>
                 <div class="col" style="margin:5px">
                    <asp:Label ID="lblConfirmPassword" runat="server" Text="Password Confirmation"></asp:Label>
                    <asp:TextBox ID="txtConfirmPassword" runat="server" class="form-control"></asp:TextBox>
                </div>
                <div class="col" style="margin:5px">
                    <asp:Button ID="Button1" class="btn btn-outline-primary" style="margin:5px" runat="server" Text="Change Password" OnClick="btnChangePassword_Click" />
                </div>
                <asp:Label ID="lblChangePasswordSuccess" style="margin:5px" runat="server"></asp:Label>
            </div>          
        </div>
    </form>
</body>
</html>
