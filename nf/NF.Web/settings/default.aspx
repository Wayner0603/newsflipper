<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="newsflippers.settings._default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <script language=javascript type="text/javascript">
     function nav(url)
    {
        //var f = document.getElementById('main_frame');
        //f.src = url;
        return false;
    }

    function navh(url, d, o)
    {
        nav(url);
        addClass(d, o);
    }

    function addClass(d, o)
    {
        var m = o.split(";");
        for (i = 0; i < m.length; i++)
        {
            document.getElementById(m[i]).className = 'nav_item';
        }
        document.getElementById(d).className = 'nav_item_selected';
    }


    function hide()
    {
        $('#div_1').hide();
        return false;
    }
    </script>
    <link href="../App_Themes/Default/skin.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="s_left">
    <div id="nav_newtask" class="nav_item"><asp:HyperLink CssClass="nav_text" ID="HyperLink2" runat="server" NavigateUrl="javascript:navh('tasks/create_task.aspx?m=c','nav_newtask','nav_starred;nav_allbugs');">Create Task</asp:HyperLink><br /></div>
<div id="nav_allbugs" class="nav_item_selected"><asp:HyperLink CssClass="nav_text" ID="HyperLink1" runat="server" NavigateUrl="javascript:navh('tasks/view_all_tasks.aspx','nav_allbugs','nav_starred;nav_newtask');">All Bugs</asp:HyperLink></div>
<div id="nav_starred" class="nav_item"><asp:HyperLink ID="HyperLink3" CssClass="nav_text" runat="server" NavigateUrl="javascript:navh('tasks/view_all_tasks.aspx','nav_starred','nav_allbugs;nav_newtask');">Starred Items</asp:HyperLink></div>
</div>
    <div id="s_cont"></div>
    </form>
</body>
</html>
