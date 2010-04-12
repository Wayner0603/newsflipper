<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sources.aspx.cs" Inherits="newsflippers.about.sources" %>
<%@ OutputCache Duration="690" VaryByParam="none" %>

<%@ Register src="../uc/HeaderUc.ascx" tagname="HeaderUc" tagprefix="uc1" %>

<%@ Register src="../uc/FooterUc.ascx" tagname="FooterUc" tagprefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Sources - newsflippers.com</title>
   <script type="text/javascript" src="../js/jquery-1.3.2.js"></script>
    <script type="text/javascript" src="../js/liquid-canvas.js"> </script>
    <script type="text/javascript" src="../js/liquid-canvas-plugins.js"> </script>
     <script type="text/javascript" src="../js/excanvas.js"> </script>
    <script type="text/javascript">
          $(document).ready(function() {
          $("#leftmenu").liquidCanvas(
            "[shadow{color:#CDCFD1}fill{color:#fff} ] => roundedRect{radius:10}");
          $("#middlecontent").liquidCanvas(
            "[shadow{color:#CDCFD1}fill{color:#fff} ] => roundedRect{radius:10}");
      });
          
          
          
          
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <uc1:HeaderUc ID="HeaderUc1" runat="server" />
    
    <table cellpadding=0 cellpadding=0><tr><td><div id="leftmenu">
        <asp:HyperLink CssClass="link" ID="HyperLink3" runat="server" 
            NavigateUrl="~/about/whats-new.aspx" ForeColor="#CC0000">New Features</asp:HyperLink>
        <br />
        <br />
        <asp:HyperLink CssClass="link" ID="HyperLink2" runat="server" 
            NavigateUrl="~/about/default.aspx">About Newsflippers</asp:HyperLink><br />
        <asp:HyperLink CssClass="link" ID="HyperLink1" runat="server" 
            NavigateUrl="~/about/default.aspx">Suggest a feature</asp:HyperLink><br />
            <asp:HyperLink CssClass="link" ID="HyperLink4" runat="server" 
            NavigateUrl="~/about/sources.aspx">News sources</asp:HyperLink><br /><br />
            <asp:HyperLink CssClass="link" ID="HyperLink5" runat="server" 
            NavigateUrl="~/">Back to News</asp:HyperLink><br />
    </div></td><td  style="vertical-align:top"><div id="middlecontent">
    <div class="text-header">News Sources</div><br />
    Currently there are only few news source has been added to the system. But we're imporving constantly. Please <a href="mailto:news@newsflippers.com">let us know</a> if you have any other news sources.<br /><br />
    <a href="http://www.divaina.com" target="_blank">Divaina</a><br />
    <a href="http://www.dailymirror.lk" target="_blank">Daily Mirror</a><br />
    <a href="http://www.infolanka.com" target="_blank">Info Lanka</a><br />
    <a href="http://www.rivira.lk" target="_blank">Rivira</a><br />
    <a href="http://www.lankadeepa.lk" target="_blank">Lankadeepa</a><br />
    <a href="http://www.lakbima.lk" target="_blank">Lakbima</a><br />
    </div></td></tr></table>
    <br /><br /><br /><br /><div class="footer-border">
    <uc2:FooterUc ID="FooterUc1" runat="server" />
    </div></form>
</body>
</html>