<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TopBar.ascx.cs" Inherits="newsflippers.uc.TopBar" %>
<div class="header_top">
    <asp:HyperLink ID="hpLogin" NavigateUrl="javascript:modal.show('/user/','Sign in to Newsflipper Account', 500,300);"
        runat="server">Sign in</asp:HyperLink><asp:Label ID="lblUser" runat="server" Text=""
            CssClass="text_bold"></asp:Label><a href="/about/">&nbsp;|&nbsp;About Newsflippers</a><asp:HyperLink
                ID="hpSingOut" NavigateUrl="~/sign_out.aspx " Visible="false" runat="server">&nbsp;|&nbsp;Sign out</asp:HyperLink></div>
