<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConfirmSurvey.aspx.cs" Inherits="TechKnowPro.ConfirmSurvey" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        
                    TechKnow Pro Incident Management Software
                
                    <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" CausesValidation="False" />
               
        
                    <br />
                    Survey Complete<br />
                    <br />
                    Thank you for your feedback!<br />
                    <asp:Label ID="lblContact" runat="server" Text="A customer service representatative will contact you within 24 hrs"></asp:Label>
                    <br />
        <asp:Button ID="btnHome" runat="server" OnClick="btnHome_Click" Text="Home" />
        <asp:Button ID="btnReturn" runat="server" Text="Return To Survey" OnClick="btnReturn_Click" />
    </form>
</body>
</html>
