<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TopBar.ascx.cs" Inherits="newsflippers.uc.TopBar" %>
<div class="header_top">
    <asp:HyperLink ID="HyperLink1" NavigateUrl="javascript:call_issues();" style="color:#CC0000;font-weight:bold" 
        runat="server">Any issues or suggestions?</asp:HyperLink>&nbsp;|&nbsp;<asp:HyperLink ID="hpLogin" NavigateUrl="javascript:call_signin();"
        runat="server">Sign in</asp:HyperLink><asp:Label ID="lblUser" runat="server" Text=""
            CssClass="text_bold"></asp:Label><a href="#">&nbsp;|&nbsp;About Newsflippers</a><asp:HyperLink
                ID="hpSingOut" NavigateUrl="~/sign_out.aspx " Visible="false" runat="server">&nbsp;|&nbsp;Sign out</asp:HyperLink></div>
