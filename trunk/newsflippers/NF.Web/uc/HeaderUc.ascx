<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HeaderUc.ascx.cs" Inherits="newsflippers.uc.HeaderUc" %>
 <script type="text/javascript">
     $(document).ready(function() {
         if (jQuery.browser.msie == true) {
             $("#browser_msg").show();
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
        ImageUrl="~/images/logo.png" /></a> </div><div style="display:none" id="browser_msg">You are currently using an unsupported browser. Please <a href="http://www.google.com/chrome">download</a> a new browser for better experience.</div>
</div>