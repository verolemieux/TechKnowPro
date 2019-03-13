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
                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="Username" DataValueField="Username">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [User]"></asp:SqlDataSource>
                </td>
            </tr>
        </table>
        <p>
            Incident List</p>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Incidents] WHERE ([Username] = @Username)">
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList1" Name="Username" PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:Panel ID="Panel1" runat="server">
            <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource2" AutoGenerateColumns="False" DataKeyNames="Incident_Num">
                <Columns>
                    <asp:BoundField DataField="Incident_Num" HeaderText="Incident_Num" ReadOnly="True" SortExpression="Incident_Num" />
                    <asp:BoundField DataField="Date_Time" HeaderText="Date_Time" SortExpression="Date_Time" />
                    <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                    <asp:BoundField DataField="Contact_Method" HeaderText="Contact_Method" SortExpression="Contact_Method" />
                    <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username" />
                    <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                </Columns>
            </asp:GridView>
        </asp:Panel>
    </form>
</body>
</html>
