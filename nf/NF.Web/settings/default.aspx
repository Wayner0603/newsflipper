<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="newsflippers.settings._default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <script type="text/javascript" src="../js/g.js"></script>
    <link href="../css/skin.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="s_left">
    <div id="nav_newtask" class="nav_item"><asp:HyperLink CssClass="nav_text" ID="HyperLink2" runat="server" NavigateUrl="javascript:menu.nav('tasks/create_task.aspx?m=c','nav_newtask','nav_starred;nav_allbugs');">Create Task</asp:HyperLink><br /></div>
<div id="nav_allbugs" class="nav_item_selected"><asp:HyperLink CssClass="nav_text" ID="HyperLink1" runat="server" NavigateUrl="javascript:menu.nav('tasks/view_all_tasks.aspx','nav_allbugs','nav_starred;nav_newtask');">All Bugs</asp:HyperLink></div>
<div id="nav_starred" class="nav_item"><asp:HyperLink ID="HyperLink3" CssClass="nav_text" runat="server" NavigateUrl="javascript:menu.nav('tasks/view_all_tasks.aspx','nav_starred','nav_allbugs;nav_newtask');">Starred Items</asp:HyperLink></div>
</div>
    <div id="s_cont"></div>
    </form>
</body>
</html>
