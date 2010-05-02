<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HeaderUc.ascx.cs" Inherits="newsflippers.uc.HeaderUc" %>
 <%@ Register src="search_uc.ascx" tagname="search_uc" tagprefix="uc1" %>
 <%@ Register src="msg_ctrl.ascx" tagname="msg_ctrl" tagprefix="uc2" %>
<div id="header">
    <div id="logo"><a href="/"><asp:Image style="border:0" ID="Image1" runat="server" 
        AlternateText="fast & easy - Newsflippers.com" 
        ImageUrl="~/images/logo.png" /></a> &nbsp;&nbsp;
    </div><div id="search"><uc1:search_uc ID="search_uc1" runat="server" /></div>
    </div>
<%--<div id="titlebar">Alpha Version</div>--%>