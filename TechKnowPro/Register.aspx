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
            <asp:ValidationSummary ID="ValidationSummary" runat="server" style="margin: auto" HeaderText="Please correct the following entries:" Width="251px" />
            <div class="form-group col-md-4" style="margin:auto">
                <div class="form-row">
                    <div class="col" style="margin:5px">
                        <asp:Label ID="lblFirstName" runat="server" Text="First Name*"></asp:Label>
                        <asp:TextBox ID="txtFirstName" class="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="valFirstName" runat="server" ControlToValidate="txtFirstName" ForeColor="Red" ErrorMessage="First Name" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col" style="margin:5px">
                        <asp:Label ID="lblLastName" runat="server" Text="Last Name*"></asp:Label>
                        <asp:TextBox ID="txtLastName" class="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="valLastName" runat="server" ControlToValidate="txtLastName" ForeColor="Red" ErrorMessage="Last Name" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group" style="margin:5px">
                    <asp:Label ID="lblAddress" runat="server" Text="Address*"></asp:Label>
                    <asp:TextBox ID="txtAddress" class="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="valAddress" runat="server" ControlToValidate="txtAddress" ForeColor="Red" ErrorMessage="Address" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group" style="margin:5px">
                    <asp:Label ID="lblEmail" runat="server" Text="Email*"></asp:Label>
                    <asp:TextBox ID="txtEmail" class="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="valEmail" runat="server" ErrorMessage="Email" ControlToValidate="txtEmail" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="regExValEmail" runat="server" ControlToValidate="txtEmail" ForeColor="Red" ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$" ErrorMessage="Valid Email" Display="Dynamic"></asp:RegularExpressionValidator>
                </div>
                <div class="form-row">
                    <div class="col" style="margin:5px">
                        <asp:Label ID="lblPassword" runat="server" Text="Password*"></asp:Label>
                        <asp:TextBox ID="txtPassword" class="form-control" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="valPassword" runat="server" ControlToValidate="txtPassword" ForeColor="Red" ErrorMessage="Password" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col" style="margin:5px">
                        <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirm Password*"></asp:Label>
                        <asp:TextBox ID="txtConfirmPassword" class="form-control" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="valPasswordConfirm" runat="server" ControlToValidate="txtConfirmPassword" ForeColor="Red" ErrorMessage="Password Confirmation" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="valComparePassword" runat="server" ForeColor="Red" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" Display="Dynamic"></asp:CompareValidator>
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
            <div>
                <asp:Label ID="lblSuccessfulRegistration" runat="server" ForeColor="Red"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
