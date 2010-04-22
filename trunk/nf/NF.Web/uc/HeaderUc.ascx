<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HeaderUc.ascx.cs" Inherits="newsflippers.uc.HeaderUc" %>
 <%@ Register src="search_uc.ascx" tagname="search_uc" tagprefix="uc1" %>
 <%@ Register src="msg_ctrl.ascx" tagname="msg_ctrl" tagprefix="uc2" %>
 <script type="text/javascript">
     $(document).ready(function() {
         if (jQuery.browser.msie == true) {
             $("#msg_browser").show();
         } 
     });

     $(document).ready(function() {
         $(window).bind("resize", resizeWindow);
         function resizeWindow(e) {
             if ($("#userlogin_div").css("display") == 'block') {
                 setSearchPanelLocation("#userlogin_div");
             }
         }
     });		
          
    </script>
<div id="header">
    <div id="logo"><a href="/"><asp:Image style="border:0" ID="Image1" runat="server" 
        AlternateText="fast & easy - Newsflippers.com" 
        ImageUrl="~/images/logo.png" /></a> &nbsp;&nbsp;
        
    </div><div id="search"><uc1:search_uc ID="search_uc1" runat="server" /></div><div style="display:none" id="msg_browser">You are currently using an unsupported browser. Please <a href="http://www.google.com/chrome">download</a> a new browser for better experience.</div>
</div>
<uc2:msg_ctrl ID="msg_ctrl1" runat="server" />

<%--<div id="titlebar">Alpha Version</div>--%>