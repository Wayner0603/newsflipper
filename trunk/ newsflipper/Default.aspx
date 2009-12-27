<%@Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="newsflippers._default"%>
<%@Register src="uc/HeaderUc.ascx" tagname="HeaderUc" tagprefix="uc1"%>
<%@Register src="uc/FooterUc.ascx" tagname="FooterUc" tagprefix="uc2"%>
<%@OutputCache Duration="90" VaryByParam="none"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title>Fastest way to read online news</title>
<meta name="keywords" content="news,srilanka,online news,fastflip,news flipper"/>
<meta name="description" content="Fastest way to read online news."/>
<script type="text/javascript" src="js/jquery-1-3-2.js"></script>
<script type="text/javascript" src="js/jCarousel.js"></script>
<script type="text/javascript" src="js/global_js.min.js"></script>
</head>
<body>
<form id="form1" runat="server">
<uc1:HeaderUc ID="HeaderUc1" runat="server" />
<div id="container">
<div id="mycarousel" class="jcarousel-skin-ie7">
<ul>
</ul>
</div></div>
<uc2:FooterUc ID="FooterUc1" runat="server" />
</form>
<script type="text/javascript">var gaJsHost=(("https:"==document.location.protocol)?"https://ssl.":"http://www.");document.write(unescape("%3Cscript src='"+gaJsHost+"google-analytics.com/ga.js' type='text/javascript'%3E%3C/script%3E"));</script>
<script type="text/javascript">try{var pageTracker=_gat._getTracker("UA-254993-16");pageTracker._trackPageview();}catch(err){}</script>
</body>
</html>