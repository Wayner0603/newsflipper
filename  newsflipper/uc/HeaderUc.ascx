<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HeaderUc.ascx.cs" Inherits="newsflippers.uc.HeaderUc" %>
 <script type="text/javascript">
     $(document).ready(function() {
         if (jQuery.browser.msie == true) {
             $("#browser_msg").show();
         } 
     });

     function showOverlay() {
         $("#overlay").show();
         $("#overlay").width($(document).width());
         $("#overlay").height($(document).height());
     }

     function closePanel(panel) {
         $(panel).hide();
     }

     function showPanel(panel) {
         //showOverlay();
        
         $(panel).show();
         setSearchPanelLocation(panel);
     }

     function setSearchPanelLocation(panel) {
         var w = ($(window).width() / 2) - ($(panel).width() / 2);
         $(panel).css("left", w);
         $(panel).css("top", 150);
     }

     $(document).ready(function() {
         $(window).bind("resize", resizeWindow);
         function resizeWindow(e) {
             if ($("#userlogin_div").css("display") == 'block') {
                 setSearchPanelLocation("#userlogin_div");
             }
         }
     });		
          
    </script>
<span class="top_menu"><a href="/about/">About Newsflippers</a></span>
<div id="header">
    <div id="logo"><a href="/"><asp:Image style="border:0" ID="Image1" runat="server" 
        AlternateText="fast & easy - Newsflippers.com" 
        ImageUrl="~/images/news_small7.png" /></a> </div><div style="display:none" id="browser_msg">You are currently using an unsupported browser. Please <a href="http://www.google.com/chrome">download</a> a new browser for better experience.</div>
</div>