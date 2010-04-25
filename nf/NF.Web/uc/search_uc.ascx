<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="search_uc.ascx.cs" Inherits="newsflippers.uc.search_uc" %>
<asp:TextBox ID="txtKeyword"  CssClass="search_box" runat="server" Width="304px"></asp:TextBox><asp:Button ID="Button1" OnClientClick="return false;" CssClass="search_btn" runat="server" Text="Search" 
    onclick="Button1_Click" />
    