<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebFormsSample.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>    

        <form runat="server">
    <% if (!Request.IsAuthenticated) { %>
                <p>
                <asp:Button ID="Button1" runat="server" OnClick="Login_Click" Text="Login" />
            </p>
    <% } else { %>
            Hi <%= User.Identity.Name %>!
            
            <h3>Your Claims</h3>  
    <p>  
        <asp:GridView ID="ClaimsGridView" runat="server" CellPadding="3">  
            <AlternatingRowStyle BackColor="White" />  
            <HeaderStyle BackColor="#7AC0DA" ForeColor="White" />  
        </asp:GridView>  
    </p>  
            <asp:Button runat="server" OnClick="Logout_Click" Text="Logout" />

   <% } %>
        </form>
 
    <p>
        &nbsp;</p>
</body>
</html>
