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

            <asp:ListBox ID="ListBox1" runat="server" DataSourceID="SqlDataSource2" DataTextField="Username" DataValueField="Username"></asp:ListBox>

        </p>
        <p>
            Incident List</p>
        <asp:FormView ID="FormView1" runat="server" DataKeyNames="Incident_Num" DataSourceID="SqlDataSource2">
            <EditItemTemplate>
                Incident_Num:
                <asp:Label ID="Incident_NumLabel1" runat="server" Text='<%# Eval("Incident_Num") %>' />
                <br />
                Date_Time:
                <asp:TextBox ID="Date_TimeTextBox" runat="server" Text='<%# Bind("Date_Time") %>' />
                <br />
                Status:
                <asp:TextBox ID="StatusTextBox" runat="server" Text='<%# Bind("Status") %>' />
                <br />
                Contact_Method:
                <asp:TextBox ID="Contact_MethodTextBox" runat="server" Text='<%# Bind("Contact_Method") %>' />
                <br />
                Username:
                <asp:TextBox ID="UsernameTextBox" runat="server" Text='<%# Bind("Username") %>' />
                <br />
                Description:
                <asp:TextBox ID="DescriptionTextBox" runat="server" Text='<%# Bind("Description") %>' />
                <br />
                <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
                &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
            </EditItemTemplate>
            <InsertItemTemplate>
                Incident_Num:
                <asp:TextBox ID="Incident_NumTextBox" runat="server" Text='<%# Bind("Incident_Num") %>' />
                <br />
                Date_Time:
                <asp:TextBox ID="Date_TimeTextBox" runat="server" Text='<%# Bind("Date_Time") %>' />
                <br />
                Status:
                <asp:TextBox ID="StatusTextBox" runat="server" Text='<%# Bind("Status") %>' />
                <br />
                Contact_Method:
                <asp:TextBox ID="Contact_MethodTextBox" runat="server" Text='<%# Bind("Contact_Method") %>' />
                <br />
                Username:
                <asp:TextBox ID="UsernameTextBox" runat="server" Text='<%# Bind("Username") %>' />
                <br />
                Description:
                <asp:TextBox ID="DescriptionTextBox" runat="server" Text='<%# Bind("Description") %>' />
                <br />
                <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
                &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
            </InsertItemTemplate>
            <ItemTemplate>
                Incident_Num:
                <asp:Label ID="Incident_NumLabel" runat="server" Text='<%# Eval("Incident_Num") %>' />
                <br />
                Date_Time:
                <asp:Label ID="Date_TimeLabel" runat="server" Text='<%# Bind("Date_Time") %>' />
                <br />
                Status:
                <asp:Label ID="StatusLabel" runat="server" Text='<%# Bind("Status") %>' />
                <br />
                Contact_Method:
                <asp:Label ID="Contact_MethodLabel" runat="server" Text='<%# Bind("Contact_Method") %>' />
                <br />
                Username:
                <asp:Label ID="UsernameLabel" runat="server" Text='<%# Bind("Username") %>' />
                <br />
                Description:
                <asp:Label ID="DescriptionLabel" runat="server" Text='<%# Bind("Description") %>' />
                <br />
            </ItemTemplate>
        </asp:FormView>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Incidents] WHERE ([Username] = @Username)">
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList1" Name="Username" PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    </form>
</body>
</html>
