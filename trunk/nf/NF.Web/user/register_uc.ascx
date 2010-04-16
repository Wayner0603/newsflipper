<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="register_uc.ascx.cs" Inherits="newsflippers.user.register_uc" %>
<p>
    Email<br />
    <asp:TextBox ID="txtEmail" runat="server" Width="306px"></asp:TextBox><br />
    Password<br />
    <asp:TextBox ID="txtPass" TextMode=Password  runat="server" Width="306px"></asp:TextBox><br />
      Confirm Password<br />
    <asp:TextBox ID="txtConfirmPassword" TextMode=Password  runat="server" Width="306px"></asp:TextBox><br />
<asp:Button ID="btnRegister" runat="server" Text="Login" 
        onclick="btnRegister_Click" />&nbsp;<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

</p>
