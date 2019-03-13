<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateIncident.aspx.cs" Inherits="TechKnowPro.CreateIncident" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 165px;
            height: 32px;
        }
        .auto-style3 {
            height: 32px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" >
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

                <td>Select a customer:<asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource2" DataTextField="Names" DataValueField="Username" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged1">
                    <asp:ListItem Selected="True" Value="nullOption">Select</asp:ListItem>
                    </asp:DropDownList>

                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Username], CONCAT(Last_Name, ', ', First_Name) as Names FROM [User]"></asp:SqlDataSource>

                    <asp:CustomValidator ID="custValidator" runat="server" ControlToValidate="DropDownList1" ErrorMessage="Select an option." OnServerValidate="custValidator_ServerValidate"></asp:CustomValidator>

                </td>

                <td>Report Date and Time:<asp:Label ID="lblDate" runat="server"></asp:Label>
                </td>

            </tr>

            <tr>

                <td>Customer ID:<asp:TextBox ID="txtCustId" runat="server" Enabled="False"></asp:TextBox>

                </td>

                <td>Incident#: 
                    <asp:Label ID="lblIncidentNum" runat="server"></asp:Label>
                </td>

            </tr>

            <tr>

                <td>
                    <asp:FormView ID="FormView1" runat="server" DataKeyNames="Username" DataSourceID="SqlDataSource1" OnDataBound="FormView1_DataBound">
                        <EditItemTemplate>
                            Username:
                            <asp:Label ID="UsernameLabel1" runat="server" Text='<%# Eval("Username") %>' />
                            <br />
                            <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
                            &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            Username:
                            <asp:TextBox ID="UsernameTextBox" runat="server" Text='<%# Bind("Username") %>' />
                            <br />
                            <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
                            &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                        </InsertItemTemplate>
                        <ItemTemplate>
                            Username:
                            <asp:Label ID="UsernameLabel" runat="server" Text='<%# Eval("Username") %>' />
                            <br />

                        </ItemTemplate>
                    </asp:FormView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Username] FROM [User] WHERE ([Username] = @Username)">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="DropDownList1" Name="Username" PropertyName="SelectedValue" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>

                <td>Status: 
                    <asp:DropDownList ID="DropDownList2" runat="server">
                        <asp:ListItem Selected="True" Value="1">NEW</asp:ListItem>
                        <asp:ListItem Value="2">IN PROGRESS</asp:ListItem>
                        <asp:ListItem Value="3">CLOSED</asp:ListItem>
                    </asp:DropDownList>
                </td>

            </tr>

            <tr>

                <td>Description of Problem:</td>

                <td>&nbsp;</td>

            </tr>

        </table>

        <asp:TextBox ID="txtDescription" runat="server" Height="149px" MaxLength="300" TextMode="MultiLine" Width="1022px"></asp:TextBox>
        <table class="auto-style1">
            <tr>
                <td>

                    <asp:RequiredFieldValidator ID="descReq" runat="server" ControlToValidate="txtDescription" ErrorMessage="Description required."></asp:RequiredFieldValidator>

                </td>
            </tr>
            <tr>
                <td class="auto-style2">Method of Contact:</td>
                <td class="auto-style3">
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Selected="True" Value="1">Email</asp:ListItem>
                        <asp:ListItem Value="2">Phone</asp:ListItem>
                        <asp:ListItem Value="3">In Person</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
        </table>
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
    </form>
</body>
</html>
