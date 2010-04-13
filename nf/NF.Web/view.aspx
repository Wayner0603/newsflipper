<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="view.aspx.cs" Inherits="newsflippers.default_new" %>

<%@ Register Src="uc/HeaderUc.ascx" TagName="HeaderUc" TagPrefix="uc1" %>
<%@ Register Src="uc/FooterUc.ascx" TagName="FooterUc" TagPrefix="uc2" %>
<%@ OutputCache Duration="20" VaryByParam="none" %>
<%@ Register Src="uc/BugFeatureRequestUc.ascx" TagName="BugFeatureRequestUc" TagPrefix="uc3" %>
<%@ Register Src="uc/TopBar.ascx" TagName="TopBar" TagPrefix="uc4" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head id="Head1" runat="server">
    <title>Fastest way to read news online</title>
    <meta name="keywords" content="news,srilanka,online news,fastflip,news flipper" />
    <meta name="description" content="Fastest way to read online news." />

    <script type="text/javascript" src="js/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="js/jspack.js"></script>
    <script type="text/javascript" src="js/jcoursalpack.js"></script>
    <script type="text/javascript" src="js/global.min.js"></script>
    <script type="text/javascript" src="js/c.js"></script>
    
    <script type="text/javascript">        $(document).ready(function() { if ($.cookie('__N') == null || $.cookie('__N') == 'false') { showPanel("#help_div"); } }); function closePanelWithCookie(div) { closePanel(div); $.cookie('__N', (document.getElementById('chkDontShow').checked), { expires: 365 }); return false; }
        var x = new Array(); 
        var u = '';
        var c = 0; var totalcount = -1; 
        function mycarousel_itemLoadCallback(carousel, state)
        {
            var url_1 = 'view.aspx?id=';
            var frag = '';
            var url = '';
            var id = url.substring(url.indexOf('?') + 1, url.length).split('=')[1];
           
            
            if (carousel.has(carousel.first, carousel.last)) { return; } if (totalcount == c) { c = c - 1; carousel.prev(); return; }
            jQuery.get("get_images.aspx?m=2&c=" + c, function(response) {
                carousel.add(response.split(';')[0], response.split(';')[1]);
                url = response.split(';')[4];
                window.location.hash = url;
                x[c] = url;
                totalcount = response.split(';')[2];
            });       $(document).keydown(function(event)
            {
                if (event.keyCode == 37)
                {
                    carousel.prev();
                    
                } else if (event.keyCode == 39) { carousel.next(); }
            });
            c = c + 1; 
           
        };

/**
 * This is the callback function which receives notification
 * about the state of the next button.
 */
        function mycarousel_buttonInCallback(carousel, item, idx, state) {
            window.location.hash = x[idx];  
};
 
/**
 * This is the callback function which receives notification
 * about the state of the prev button.
 */
jQuery(document).ready( function() {
            jQuery('#mycarousel').jcarousel({ scroll: 1, animation: 200, itemLoadCallback: mycarousel_itemLoadCallback ,
             itemFirstInCallback: mycarousel_buttonInCallback
            });
            
            }
       
        );
   
       </script>

    <link href="App_Themes/Default/skin_view.css" rel="stylesheet" type="text/css" />
    <link href="App_Themes/Default/skin.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <uc4:TopBar ID="TopBar1" runat="server" />
    <uc1:HeaderUc ID="HeaderUc1" runat="server" />
    <div id="page">
        <div id="news">
            <div id="mycarousel" class="jcarousel-skin-ie7">
                <ul>
                </ul>
            </div>
        </div>
    </div>
    <uc2:FooterUc ID="FooterUc1" runat="server" />

    <script type="text/javascript">        var gaJsHost = (("https:" == document.location.protocol) ? "https://ssl." : "http://www."); document.write(unescape("%3Cscript src='" + gaJsHost + "google-analytics.com/ga.js' type='text/javascript'%3E%3C/script%3E"));</script>

    <script type="text/javascript">        try { var pageTracker = _gat._getTracker("UA-254993-16"); pageTracker._trackPageview(); } catch (err) { }</script>

    <uc3:BugFeatureRequestUc ID="BugFeatureRequestUc1" runat="server" />
    <div id="help_div">
        <div class="popup_outer">
            <div class="popup_container">
                <div class="popup_header">
                    How to Navigate through news</div>
                <div class="popup_content">
                    Use the <b>Left</b> and <b>Right</b> arrow keys on your keboard or click on the
                    <span class="larger-text">&lt;</span> or <span class="larger-text">&gt;</span> images
                    on the page.<br />
                    <br />
                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn" OnClientClick="return closePanelWithCookie('#help_div');"><span><span>Okay</span></span></asp:LinkButton>&nbsp;<asp:CheckBox
                        Text="Don't show me this again" ID="chkDontShow" Checked="true" runat="server" /></div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
