<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="TechKnowPro.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/bootstrap.css" rel="stylesheet" />
</head>
<body class="text-center">
    <form id="form1" method="post" runat="server">
        <div class="container-fluid centered" style="margin: 0 auto; text-align:center">
            <h1 style="margin:5px">Register</h1>
            <div class="form-group col-md-4" style="margin:auto">
                <div class="form-row">
                    <div class="col" style="margin:5px">
                        <asp:Label ID="lblFirstName" runat="server" Text="First Name*"></asp:Label>
                        <asp:TextBox ID="txtFirstName" name="First Name" class="form-control" value="@Request.Form['First Name']" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="valFirstName" runat="server" ErrorMessage="First Name Required!" ControlToValidate="txtFirstName" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col" style="margin:5px">
                        <asp:Label ID="lblLastName" runat="server" Text="Last Name*"></asp:Label>
                        <asp:TextBox ID="txtLastName" name="Last Name" class="form-control" value="@Request.Form['Last Name']" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="valLastName" runat="server" ErrorMessage="Last Name Required!" ControlToValidate="txtLastName" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group" style="margin:5px">
                    <asp:Label ID="lblAddress" runat="server" Text="Address*"></asp:Label>
                    <asp:TextBox ID="txtAddress" name="Address" class="form-control" value="@Request.Form['Address']" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="valAddress" runat="server" ErrorMessage="Address Required!" ControlToValidate="txtAddress" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group" style="margin:5px">
                    <asp:Label ID="lblEmail" runat="server" Text="Email*"></asp:Label>
                    <asp:TextBox ID="txtEmail" name="Email" class="form-control" value="@Request.Form['Email']" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="valEmail" runat="server" ErrorMessage="Email Required!" ControlToValidate="txtEmail" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="regExValEmail" runat="server" ErrorMessage="Valid Email Required!" ControlToValidate="txtEmail" ForeColor="Red" ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"></asp:RegularExpressionValidator>
                </div>
                <div class="form-row">
                    <div class="col" style="margin:5px">
                        <asp:Label ID="lblPassword" runat="server" Text="Password*"></asp:Label>
                        <asp:TextBox ID="txtPassword" name="Password" class="form-control" value="@Request.Form['Password']" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="valPassword" runat="server" ErrorMessage="Password Required!" ControlToValidate="txtPassword" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col" style="margin:5px">
                        <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirm Password*"></asp:Label>
                        <asp:TextBox ID="txtConfirmPassword" class="form-control" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="valPasswordConfirm" runat="server" ErrorMessage="Password Confirmation Required!" ControlToValidate="txtConfirmPassword" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="valComparePassword" runat="server" ErrorMessage="Password Confirmation must match Password!" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" ForeColor="Red"></asp:CompareValidator>
                    </div>
                </div>
            </div>
            <div style="margin:5px">
                <asp:CheckBox ID="cbTerms" runat="server" Text="I agree to the terms of service*" /><br />
            </div>
            <div>
                <asp:Button ID="btnRegister" class="btn btn-outline-primary" style="margin:5px" runat="server" Text="Register" OnClick="btnRegister_Click" />
                <asp:Button ID="btnCancel" class="btn btn-primary" runat="server" style="margin:5px" Text="Cancel" CausesValidation="false" PostBackUrl="~/Login.aspx"/><br />
            </div>
        </div>
    </form>
</body>
</html>
