<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HeaderUc.ascx.cs" Inherits="newsflippers.uc.HeaderUc" %>
<style type="text/css">
    .style1
    {
        text-decoration: none;
    }
    .style2
    {
    vertical-align:top;
    font-weight:normal;
    }
    
    
</style>

 <script type="text/javascript">
     $(document).ready(function() {
         if (jQuery.browser.msie == true) {
             $("#browser_msg").show();
         } 
     });
          
          
    </script>
<span class="userlogin"><a href="../about/sources.aspx" class="style1">
<span class=style2 >It's your news your way</span></a> </span>
<div id="header">
    <div id="logo"><a href="/"><asp:Image style="border:0" ID="Image1" runat="server" 
        AlternateText="fast & easy - Newsflippers.com" 
        ImageUrl="~/images/new_logo.png" /></a> </div><div style="display:none" id="browser_msg">You are currently using an unsupported browser. Please <a href="http://www.google.com/chrome">download</a> a new browser for better experience.</div>
</div>
