<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateIncident.aspx.cs" Inherits="TechKnowPro.CreateIncident" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <table class="auto-style1">

            <tr>

                <td>TechKnow Pro Incident Management Software</td>

                <td>

                    <asp:Button ID="btnLogout" runat="server" Text="Logout" />

                </td>

            </tr>

        </table>

        <div>

            <br />

            Incident Report Page</div>

        <table class="auto-style1">

            <tr>

                <td>Select a customer:<asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource2" DataTextField="Username" DataValueField="Username" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged1"></asp:DropDownList>

                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT Username FROM [User]"></asp:SqlDataSource>

                </td>

                <td>Report Date and Time:</td>

            </tr>

            <tr>

                <td>Customer ID:<asp:TextBox ID="txtCustId" runat="server"></asp:TextBox>

                </td>

                <td>Incident#: </td>

            </tr>

            <tr>

                <td>&nbsp;</td>

                <td>Status: </td>

            </tr>

        </table>

        <asp:TextBox ID="TextBox1" runat="server" Height="149px" MaxLength="300" TextMode="MultiLine" Width="1022px"></asp:TextBox>
    </form>
</body>
</html>
