<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HeaderUc.ascx.cs" Inherits="newsflippers.uc.HeaderUc" %>
<style type="text/css">
    .style1
    {
        text-decoration: none;
    }
    .style2
    {
        color: #CC0000;
    }
</style>
<span class="userlogin"><a href="../about/whats-new.aspx" class="style1">
<span class="style2">New Features - Keyboard shortcuts</span></a> </span>
<div id="header">
    <a href="/"><asp:Image style="border:0" ID="Image1" runat="server" AlternateText="fast & easy - Newsflippers.com" ImageUrl="~/images/new_logo.gif" /></a> 
</div><div id="header-bottom">
<asp:Label 
        ID="Label1" runat="server"  Text="Initial Preview Release for Sri Lanka"></asp:Label>
</div>
