﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateIncident.aspx.cs" Inherits="TechKnowPro.CreateIncident" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
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
                <td>Select a customer:</td>
                <td>Report Date and Time:</td>
            </tr>
            <tr>
                <td>Customer ID:</td>
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
