<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TechKnowPro.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href="css/bootstrap.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 69px;
        }
        .auto-style3 {
            width: 413px;
        }
        
    </style>

</head>
<body class="text-center">
    <form id="form1" runat="server">
        <div class="container-fluid centered" style="margin: 0 auto; text-align:center">
            <h1 style="margin:5px">LOGIN</h1>
            <asp:Label ID="lblLoginErr" style="margin:5px" runat="server" ForeColor="Red"></asp:Label>
            <div class="form-group col-md-4" style="margin:auto">
                <asp:TextBox ID="txtUsername" class="form-control" style="margin:5px" placeholder="Username" runat="server"></asp:TextBox>
                <asp:TextBox ID="txtPassword" runat="server" class="form-control" style="margin:5px" placeholder="Password" TextMode="Password"></asp:TextBox>
            </div>
            <asp:Button ID="btnLogin" class="btn btn-outline-primary" style="margin:5px" runat="server" Text="Login" OnClick="btnLogin_Click" />
            <asp:Button ID="btnRegister" class="btn btn-primary" style="margin:5px" runat="server" Text="Register" OnClick="btnRegister_Click" /><br/>
            <asp:HyperLink ID="linkPassword" runat="server" NavigateUrl="~/ForgotPassword.aspx">Forgot your password?</asp:HyperLink>   
        </div>
    </form>
</body>
</html>
