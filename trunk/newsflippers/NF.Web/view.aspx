<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="view.aspx.cs" Inherits="newsflippers.default_new" %>

<%@ Register Src="uc/HeaderUc.ascx" TagName="HeaderUc" TagPrefix="uc1" %>
<%@ Register Src="uc/FooterUc.ascx" TagName="FooterUc" TagPrefix="uc2" %>
<%@ OutputCache Duration="20" VaryByParam="none" %>
<%@ Register Src="uc/BugFeatureRequestUc.ascx" TagName="BugFeatureRequestUc" TagPrefix="uc3" %>
<%@ Register src="uc/TopBar.ascx" tagname="TopBar" tagprefix="uc4" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head id="Head1" runat="server">
    <title>Fastest way to read news online</title>
    <meta name="keywords" content="news,srilanka,online news,fastflip,news flipper" />
    <meta name="description" content="Fastest way to read online news." />

    <script type="text/javascript" src="js/jquery-1.3.2.min.js"></script>

    <script type="text/javascript" src="js/global.min.js"></script>

    <script type="text/javascript"> $(document).ready(function() { if ($.cookie('__N') == null || $.cookie('__N') == 'false') { showPanel("#help_div"); } }); function closePanelWithCookie(div) { closePanel(div); $.cookie('__N', (document.getElementById('chkDontShow').checked), { expires: 365 }); return false; }</script>

</head>
<body>
    <form id="form1" runat="server">
    <uc4:TopBar ID="TopBar1" runat="server" />
 
        <uc1:HeaderUc ID="HeaderUc1" runat="server" />
        <div id="titlebar">Alpha Version</div>
        
        <div id="page">
            <div id="news">
                <div id="mycarousel" class="jcarousel-skin-ie7">
                    <ul>
                    </ul>
                </div>
            </div>
        </div>
        <uc2:FooterUc ID="FooterUc1" runat="server" />

        <script type="text/javascript"> var gaJsHost = (("https:" == document.location.protocol) ? "https://ssl." : "http://www."); document.write(unescape("%3Cscript src='" + gaJsHost + "google-analytics.com/ga.js' type='text/javascript'%3E%3C/script%3E"));</script>

        <script type="text/javascript">try { var pageTracker = _gat._getTracker("UA-254993-16"); pageTracker._trackPageview(); } catch (err) { }</script>

  
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
