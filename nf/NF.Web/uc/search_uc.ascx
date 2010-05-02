<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="search_uc.ascx.cs" Inherits="newsflippers.uc.search_uc" %>
<%@ Register assembly="Infonex.Web.UI" namespace="Infonex.Web.UI" tagprefix="iwt" %>
<asp:TextBox ID="txtKeyword"  CssClass="search_box" runat="server" Width="304px"></asp:TextBox>&nbsp;<iwt:ButtonControl 
    ID="ButtonControl1" runat="server">
    Search</iwt:ButtonControl>

    