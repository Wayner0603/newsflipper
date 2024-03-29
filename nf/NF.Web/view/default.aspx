﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="newsflippers.view._default" %>
<%@ Register Src="../uc/HeaderUc.ascx" TagName="HeaderUc" TagPrefix="uc1" %>
<%@ Register Src="../uc/FooterUc.ascx" TagName="FooterUc" TagPrefix="uc2" %>
<%@ Register Src="../uc/BugFeatureRequestUc.ascx" TagName="BugFeatureRequestUc" TagPrefix="uc3" %>
<%@ Register Src="../uc/TopBar.ascx" TagName="TopBar" TagPrefix="uc4" %>
<%@ Register Src="../uc/modal_dialog.ascx" TagName="modal_dialog" TagPrefix="uc5" %>

<%@ Register assembly="Infonex.Web.UI" namespace="Infonex.Web.UI" tagprefix="iwt" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head id="Head1" runat="server">
    <title>Fastest way to read news online</title>
    <meta name="keywords" content="news,srilanka,online news,fastflip,news flipper" />
    <meta name="description" content="Fastest way to read online news." />
    
    <link href="../css/skin.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <uc4:TopBar ID="TopBar1" runat="server" />
    <iwt:PageManager ID="PageManager1" runat="server">
        <Scripts>
            <iwt:ScriptFile Enable="True" File="~/js/jquery.jcarousel.min.js" />
            <iwt:ScriptFile Enable="True" File="~/js/hp.js" />
        </Scripts>
    </iwt:PageManager>
    <iwt:ModalDialog ID="ModalDialog1" runat="server" />
    <uc1:HeaderUc ID="HeaderUc1" runat="server" />
    <div id="toolbar">
        <li><a  id='star' href="javascript:setStar();" class="unstar" >Add Star</a></li>
        <li><a id='email' href="javascript:c_email();" class="email">Email</a></li>
        <li><a id='full_story' href="#" class="full_story"></a></li>
        <li><a href="javascript:call_directlink(escape(window.location.href));" class="out_link">Link</a></li>
        
    </div>
    
    <div id="page">
        <div id="carousel">
            <div id="mcar" class="jcarousel-skin-ie7">
                <ul>
                </ul>
            </div>
        </div>
    </div>
    <uc2:FooterUc ID="FooterUc1" runat="server" />
    <script type="text/javascript">
        var _titles = new Array();
        var _uniqId = '';
        var _title = '';
        var _uniqIds = new Array();
        var _count = 0; var totalcount = -1;
        var _ids = new Array();
        var _id = '';
        var type = '';
        var imName = '';

        function mycarousel_itemLoadCallback(carousel, state) {

            if (carousel.has(carousel.first, carousel.last)) {
                return;
            }

            if (totalcount == _count) {
                _count = _count - 1;
                carousel.prev();
                return;
            }

            jQuery.get("../get_view.aspx?c=" + _count + '&type=' + type + '&imname=' + _uniqId, function (response) {
                carousel.add(response.split(';')[0], response.split(';')[1]);
                get_fullstory(response.split(';')[3]);

                _uniqId = response.split(';')[4];
                _uniqIds[_count] = _uniqId;
                _titles[_count] = response.split(';')[3];
                _title = response.split(';')[7];
                _id = response.split(';')[6];
                _ids[_count] = _id;

                window.location.hash = _uniqId;

                //Set the star
                getStar(_uniqId);

                totalcount = response.split(';')[2];

            }); $(document).keydown(function (event) {
                if (event.keyCode == 37) {
                    carousel.prev();

                } else if (event.keyCode == 39) { carousel.next(); }
            });
            _count = _count + 1;

        };

        function get_fullstory(url) {
            $("#full_story").html("<a target='_blank' href=" + url + ">Read Full Story</a>");
        }

        function mycarousel_buttonInCallback(carousel, item, idx, state) {
            get_fullstory(_titles[idx]);
            window.location.hash = _uniqIds[idx];
            getStar(location.href.substring(location.href.indexOf('#') + 1, location.href.length));
        };

        jQuery(document).ready(function () {
            msg.html('You can <a href="javascript:call_signin();">login or register</a> and your account details will be preserved for the final release.', 15000);
            type = location.href.substring(location.href.indexOf('?') + 1, location.href.indexOf('#'));
            _uniqId = location.href.substring(location.href.indexOf('#') + 1, location.href.length);

            jQuery('#mcar').jcarousel({ scroll: 1, animation: 200, itemLoadCallback: mycarousel_itemLoadCallback,
                itemFirstInCallback: mycarousel_buttonInCallback
            });
        }
        );

        function getStar(__id) {
            $.ajax({
                type: "POST",
                url: "/services/SourceService.asmx/IsStarred",
                data: "{'itemId':'" + __id + "'}",
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
            } else {
                star = 'true';
            }
            var uu = location.href.substring(location.href.indexOf('#') + 1, location.href.length);
            $.ajax({
                type: "POST",
                url: "/services/SourceService.asmx/DoStarred",
                data: "{'itemId':'" + uu + "', 'isStarred':'" + star + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (text) {
                    if (text.d == false) {
                        msg.html("Please <a href='javascript:call_signin();'>Sign in</a> to star items.");
                        $("#star").removeClass("star").addClass("unstar");
                    } else {
                        if (star == 'false') {
                            $("#star").removeClass("star").addClass("unstar");

                        } else {
                            $("#star").removeClass("unstar").addClass("star");
                        }
                        msg.text('Saved!');
                    }
                },
                error: function (text) {
                    $("#star").removeClass("star").addClass("unstar");
                    $("#star").addClass("unstar");
                    msg.err(text.d);
                }
            });
        }

        function c_email() {
            call_email(_title.replace(':', '').replace("'", ""), escape(window.location.href));
        }
    </script>
    </form>
</body>
</html>
