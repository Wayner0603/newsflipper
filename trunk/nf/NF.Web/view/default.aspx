<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="newsflippers.view._default" %>

<%@ Register Src="../uc/HeaderUc.ascx" TagName="HeaderUc" TagPrefix="uc1" %>
<%@ Register Src="../uc/FooterUc.ascx" TagName="FooterUc" TagPrefix="uc2" %>
<%@ OutputCache Duration="20" VaryByParam="none" %>
<%@ Register Src="../uc/BugFeatureRequestUc.ascx" TagName="BugFeatureRequestUc" TagPrefix="uc3" %>
<%@ Register Src="../uc/TopBar.ascx" TagName="TopBar" TagPrefix="uc4" %>
<%@ Register src="../uc/modal_dialog.ascx" tagname="modal_dialog" tagprefix="uc5" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head id="Head1" runat="server">
    <title>Fastest way to read news online</title>
    <meta name="keywords" content="news,srilanka,online news,fastflip,news flipper" />
    <meta name="description" content="Fastest way to read online news." />

    <script type="text/javascript" src="../js/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="../js/jspack.js"></script>
    <script type="text/javascript" src="../js/jcoursalpack.js"></script>
    <script type="text/javascript" src="../js/g.js"></script>
    <script type="text/javascript" src="../js/c.js"></script>

    <script type="text/javascript">        $(document).ready(function() { if ($.cookie('__N') == null || $.cookie('__N') == 'false') { showPanel("#help_div"); } }); function closePanelWithCookie(div) { closePanel(div); $.cookie('__N', (document.getElementById('chkDontShow').checked), { expires: 365 }); return false; }
        var x = new Array();
        var ids = new Array();
        var cId = '';
        var u = '';
        var c = 0; var totalcount = -1; 
        var type = '';
        var imName = '';

        function mycarousel_itemLoadCallback(carousel, state) {
            var url_1 = 'view.aspx?id=';
            var frag = '';
            var url = '';
            var id = url.substring(url.indexOf('?') + 1, url.length).split('=')[1];
            
            if (carousel.has(carousel.first, carousel.last)) { return; } if (totalcount == c) { c = c - 1; carousel.prev(); return; }
            jQuery.get("../get_view.aspx?c=" + c + '&type=' + type + '&imname=' + imName, function (response) {
                carousel.add(response.split(';')[0], response.split(';')[1]);
                url = response.split(';')[4];
                $("#src").html('<a href=/view/?source:' + escape(response.split(';')[5]) + '#' + url + '>' + response.split(';')[5] + '</a>');
                window.location.hash = url;
                x[c] = url;
                ids[c] = response.split(';')[6];
                cId = ids[c];
                updateStar(cId);
                totalcount = response.split(';')[2];
            });            $(document).keydown(function(event)
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
            $("#src").text(x[idx]);
            window.location.hash = x[idx];
            updateStar(ids[idx]);
};
 
/**
 * This is the callback function which receives notification
 * about the state of the prev button.
 */
jQuery(document).ready( function() {
            jQuery('#mcar').jcarousel({ scroll: 1, animation: 200, itemLoadCallback: mycarousel_itemLoadCallback ,
             itemFirstInCallback: mycarousel_buttonInCallback
            });
            type = location.href.substring(location.href.indexOf('?') + 1, location.href.indexOf('#'));
            imName = location.href.substring(location.href.indexOf('#') + 1, location.href.length);
            }
            
        );

        function updateStar(itmId) {
            $.ajax({
                type: "POST",
                url: "/services/SourceService.asmx/IsStarred",
                data: "{'itemId':'" + cId + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (text) {
                    if (text.d == false) {
                        $("#star").removeClass("star").addClass("unstar");
                    } else {
                        $("#star").removeClass("unstar").addClass("star");
                    }
                },
                error: function (text) {
                }
            });
        }

        function setStar() {
            var star = '';
            if ($("#star").hasClass("star")) {
                star = 'false';
                $("#star").removeClass("star");
                $("#star").addClass("unstar");
            } else {
                star = 'true';
                $("#star").removeClass("unstar");
                $("#star").addClass("star");
            }

            $.ajax({
                type: "POST",
                url: "/services/SourceService.asmx/DoStarred",
                data: "{'itemId':'" + cId + "', 'isStarred':'" + star + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (text) {
                    if (text.d == false) {
                        msg.err("Please login!");
                        $("#star").removeClass("star").addClass("unstar");
                    }
                },
                error: function (text) {
                    $("#star").removeClass("star").addClass("unstar");
                    $("#star").addClass("unstar");
                    msg.err(text.d);
                }
            });
        }

        function showLink() {
            modal.showHtml('<div> URL: ' + location.href + '</div>','Link to Url', 400,100);
        }
       </script>

    <link href="../css/skin.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <uc4:TopBar ID="TopBar1" runat="server" />
    <uc1:HeaderUc ID="HeaderUc1" runat="server" />
    <div id="toolbar"><div id="star" class="unstar" onclick="setStar();"></div><div id='src'></div><div onclick="showLink();">Link</div></div>
    <div id="page">
        <div id="carousel">
            <div id="mcar" class="jcarousel-skin-ie7">
                <ul>
                </ul>
            </div>
        </div>
    </div>
    <uc2:FooterUc ID="FooterUc1" runat="server" />
    <uc5:modal_dialog ID="modal_dialog1" runat="server" />
    </form>
</body>
</html>

