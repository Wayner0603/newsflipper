<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="newsflippers.admin._default" %>
<%@OutputCache Duration="90" VaryByParam="none"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <br />
    <br />
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
        Text="Generate Text" />
&nbsp;
    <asp:Button ID="Button2" runat="server" onclick="Button2_Click" 
        Text="Generate Links" />
    &nbsp;<asp:Button ID="Button3" runat="server" onclick="Button3_Click" 
        Text="Create Folders" />
    <br />
    <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
    <br />
    <asp:Label ID="Label2" runat="server"></asp:Label>
</asp:Content>
