<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Survey.aspx.cs" Inherits="TechKnowPro.Surveys" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
            Surveys - Collect feedback form Customers<asp:SqlDataSource ID="dbIncidents" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Incident_Num] FROM [Incidents] WHERE ([Status] = @Status)">
                <SelectParameters>
                    <asp:Parameter DefaultValue="0" Name="Status" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="dbSurveys" runat="server"></asp:SqlDataSource>
            <br />
            Customer ID:
            <asp:Label ID="lblCustomerID" runat="server"></asp:Label>
         </div>
         <asp:ListBox ID="listIncidents" runat="server" DataSourceID="dbIncidents"></asp:ListBox>
         <br />
         <br />
         <h3>Please rate this incident by the following categories:</h3>Response Time:
         <asp:RadioButtonList ID="radListResponse" runat="server" RepeatDirection="Horizontal">
             <asp:ListItem Value="Not Satisfied">Not Satisfied</asp:ListItem>
             <asp:ListItem Value="Somewhat Satisfied">Somewhat Satisfied</asp:ListItem>
             <asp:ListItem>Satisfied</asp:ListItem>
             <asp:ListItem>Completely Satisifed</asp:ListItem>
         </asp:RadioButtonList>
         <br />
         Technician Efficiency:
         <asp:RadioButtonList ID="radListTech" runat="server" RepeatDirection="Horizontal">
             <asp:ListItem Value="Not Satisfied">Not Satisfied</asp:ListItem>
             <asp:ListItem Value="Somewhat Satisfied">Somewhat Satisfied</asp:ListItem>
             <asp:ListItem>Satisfied</asp:ListItem>
             <asp:ListItem>Completely Satisifed</asp:ListItem>
         </asp:RadioButtonList>
         <br />
         Problem Resolution:
         <asp:RadioButtonList ID="radListResolution" runat="server" RepeatDirection="Horizontal">
             <asp:ListItem Value="Not Satisfied">Not Satisfied</asp:ListItem>
             <asp:ListItem Value="Somewhat Satisfied">Somewhat Satisfied</asp:ListItem>
             <asp:ListItem>Satisfied</asp:ListItem>
             <asp:ListItem>Completely Satisifed</asp:ListItem>
         </asp:RadioButtonList>
         <br />
         Additional Comments:<br />
         <asp:TextBox ID="txtAddComments" runat="server" Height="82px" Width="415px"></asp:TextBox>
         <br />
         <asp:CheckBox ID="chkContact" runat="server" Text="Please contact me to discuss this incident" />
         <asp:RadioButtonList ID="radListContact" runat="server" RepeatDirection="Horizontal" Visible="False">
             <asp:ListItem Value="Email">Contact via Email</asp:ListItem>
             <asp:ListItem Value="phone">Contact via phone</asp:ListItem>
         </asp:RadioButtonList>
         <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
         <asp:RequiredFieldValidator ID="validatorContact" runat="server" ErrorMessage="Please choose a contact method" ForeColor="Red" Visible="False"></asp:RequiredFieldValidator>
    </form>
</body>
</html>
