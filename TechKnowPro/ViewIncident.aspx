<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewIncident.aspx.cs" Inherits="TechKnowPro.ViewIncident" %>

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
        <div>
            <table class="auto-style1">
                <tr>
                    <td>TechKnow Pro - Incident Management Software</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
        <p>
            View Incident</p>
        <table class="auto-style1">
            <tr>
                <td>Select a customer:</td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="Username" DataValueField="Username" AppendDataBoundItems = "true">
                    <asp:ListItem Selected = "True" Text = "" Value = ""></asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [User]">
                        
                    </asp:SqlDataSource>
                </td>
            </tr>
        </table>
        <p>

            <asp:ListBox ID="ListBox1" runat="server" DataSourceID="SqlDataSource2" DataTextField="LISTITEM" DataValueField="Incident_Num" Width="546px"></asp:ListBox>

        </p>
        <p>
            Incident List</p>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT Incident_Num, CONCAT('Incident Number: ', Incident_Num, ', Status: ', Status) AS LISTITEM FROM Incidents WHERE (Username = @Username)">
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList1" Name="Username" PropertyName="SelectedValue" Type="String" DefaultValue=""/>
            </SelectParameters>
        </asp:SqlDataSource>
    </form>
</body>
</html>
