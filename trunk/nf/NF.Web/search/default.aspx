<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="newsflippers.search._default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="../uc/HeaderUc.ascx" TagName="HeaderUc" TagPrefix="uc1" %>
<%@ Register Src="../uc/FooterUc.ascx" TagName="FooterUc" TagPrefix="uc2" %>
<%@ Register Src="../uc/TopBar.ascx" TagName="TopBar" TagPrefix="uc4" %>

<%@ Register src="../uc/modal_dialog.ascx" tagname="modal_dialog" tagprefix="uc3" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <script type="text/javascript" src="../js/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="../js/g.js"></script>
    <link href="../App_Themes/Default/skin.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
          <uc4:TopBar ID="TopBar1" runat="server" />
     <uc1:HeaderUc ID="HeaderUc1" runat="server" />
    <div id="page">
        <asp:DataList ID="DataList1" runat="server" RepeatDirection="Horizontal" 
            RepeatColumns="3">
            <ItemTemplate>
            <div class="thumb"><a href='<%# GetUrl(DataBinder.Eval(Container.DataItem,"ImageName")) %>'><asp:Image ID="Image1" Width="320px" Height="360px" ImageUrl='<%# DataBinder.Eval(Container.DataItem,"FullThumbnailImagePath") %>' runat="server" /></a></div>
            <div class="list_title">
            <a href='<%# GetUrl(DataBinder.Eval(Container.DataItem,"ImageName")) %>'><asp:Label ID="lblTitle" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Title") %>'></asp:Label></a> </div>
            </ItemTemplate>
        </asp:DataList>
    </div>
    <asp:HiddenField ID="__Q" runat="server" />
    <uc2:FooterUc ID="FooterUc1" runat="server" />
          <uc3:modal_dialog ID="modal_dialog1" runat="server" />
    </form>
</body>
</html>
