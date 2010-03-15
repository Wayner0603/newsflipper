<%@ Page Title="" Language="C#" MasterPageFile="~/about/about.Master" AutoEventWireup="true" CodeBehind="whats-new.aspx.cs" Inherits="newsflippers.about.whats_new" %>
<%@OutputCache Duration="690" VaryByParam="none"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>What's new in Newsflippers.com</h3>
        We're still working to make Newsflippers.com a better place to read news, and we're listening closely to your suggestions. If you have anything you'd like to tell us, don't hesitate to <a href=default.aspx>let us know</a> , and keep checking back for additions and improvements.<ul>
        <span class="text-launched">Just launched!</span> - <b>Use Right and Left arrow keys - </b>
        Now you can flip through news using <b>Right</b> and <b>Left</b> arrow keys in your keyboard.
    </ul>
    <img src="../images/keyboard.gif" />
    <p>
        &nbsp;</p>
</asp:Content>
