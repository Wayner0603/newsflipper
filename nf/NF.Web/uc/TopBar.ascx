<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TopBar.ascx.cs" Inherits="newsflippers.uc.TopBar" %>
<div class="header_top"><a href="/about/"><asp:HyperLink ID="hpLogin" NavigateUrl="javascript:modal.show('/user/');"  runat="server">Login</asp:HyperLink>&nbsp;|&nbsp;About Newsflippers</a>&nbsp;|&nbsp;<asp:Label ID="lblUser" runat="server"
        Text=""></asp:Label></div>


