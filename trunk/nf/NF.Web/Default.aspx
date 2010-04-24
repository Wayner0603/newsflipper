<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="newsflippers._default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="uc/HeaderUc.ascx" TagName="HeaderUc" TagPrefix="uc1" %>
<%@ Register Src="uc/FooterUc.ascx" TagName="FooterUc" TagPrefix="uc2" %>
<%@ Register Src="uc/TopBar.ascx" TagName="TopBar" TagPrefix="uc4" %>
<%@ Register Src="uc/modal_dialog.ascx" TagName="modal_dialog" TagPrefix="uc3" %>
<%@ Register src="uc/msg_ctrl.ascx" tagname="msg_ctrl" tagprefix="uc5" %>
<head id="Head1" runat="server">
    <title></title>

    <script type="text/javascript" src="js/jquery-1.3.2.min.js"></script>

    <script type="text/javascript" src="js/car.js"></script>

    <script type="text/javascript" src="js/jquery.mousewheel.pack.js"></script>

    <script type="text/javascript" src="js/g.js"></script>

    <script type="text/javascript">
        jQuery(document).ready(function () {
            if (jQuery.browser.msie == true) {
                msg.html('You are currently using an unsupported browser. Please <a href="http://www.google.com/chrome">download</a> a new browser for better experience.');
            }
            load_thumb('top');
            msg.text("testssss");
        });
       
      

       var load='';
       var lst = 'top;bus;sci;ent;sta';
       
       function set_links(type) {
            var l = lst.split(';');
            for (i = 0; i < l.length; i++) {
                if (l[i] != type) {
                    jQuery('#d_' + l[i]).hide();
                    $("#" + l[i] + '_l').removeClass('menu_selected');
                }
            }
            jQuery('#d_' + type).show();
            $("#" + type + '_l').addClass('menu_selected');
        }
        
        function showHide() {
            jQuery('#c_top').hide();
        }
        
         function showj() {
            jQuery('#c_top').show();
        }
        
        function load_thumb(t)
        {
           if(load.indexOf(t) == -1) {
            
            $("#c_" + t).text('Loading...');
            
            $.ajax({
                type: "POST",
                url: '/services/SourceService.asmx/GetResponse',
                data: "{'type':'section:top+stories'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(text) {
                    $("#c_" + t).html(text.d);

                    $("#c_" +t).jCarouselLite({
                        btnNext: "#next_" + t,
                        btnPrev: "#prev_" + t,
                        mouseWheel: true,
                        visible:3,
                        scroll:3
                    });
                },
                
                error: function(text) {
                    alert(text.d);
                }
            });
            load += t + ',';
            }
            set_links(t);
        }
        
    </script>

    <link href="css/skin.css" rel="stylesheet" type="text/css" />

</head>
<body>
    <form id="form1" runat="server">
    <uc4:TopBar ID="TopBar1" runat="server" />
    <uc5:msg_ctrl ID="msg_ctrl1" runat="server" />
    <uc1:HeaderUc ID="HeaderUc1" runat="server" />
    <div id="wrap">
        <div class="menu_bar">
            <span id="top_l" class="menu_item" onclick="load_thumb('top');">Top Stories</span>&nbsp;&nbsp;&nbsp;<span
                class="menu_item" id="bus_l" onclick="load_thumb('bus');">Business</span>&nbsp;&nbsp;&nbsp;<span
                    class="menu_item" id="sci_l" onclick="load_thumb('sci');">Sci/Tech</span>&nbsp;&nbsp;&nbsp;<span
                        class="menu_item" id="ent_l" onclick="load_thumb('ent');">Entertainment</span>&nbsp;&nbsp;&nbsp;<span
                            class="menu_item" id="sta_l" onclick="load_thumb('sta');">Starred</span></div>
        <div id="carousel">
            <div id="d_top">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <div id="prev_top" class="prev">
                            </div>
                        </td>
                        <td>
                            <div id="c_top">
                                <ul>
                                    <li></li>
                                </ul>
                            </div>
                        </td>
                        <td>
                            <div id="next_top" class="next">
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
            <div id="d_bus">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <div id="prev_bus" class="prev">
                            </div>
                        </td>
                        <td>
                            <div id="c_bus">
                                <ul>
                                    <li></li>
                                </ul>
                            </div>
                        </td>
                        <td>
                            <div id="next_bus" class="next">
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
            <div id="d_sci">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <div id="prev_sci" class="prev">
                            </div>
                        </td>
                        <td>
                            <div id="c_sci">
                                <ul>
                                    <li></li>
                                </ul>
                            </div>
                        </td>
                        <td>
                            <div id="next_sci" class="next">
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
            <div id="d_ent">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <div id="prev_ent" class="prev">
                            </div>
                        </td>
                        <td>
                            <div id="c_ent">
                                <ul>
                                    <li></li>
                                </ul>
                            </div>
                        </td>
                        <td>
                            <div id="next_ent" class="next">
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
            <div id="d_sta">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <div id="prev_sta" class="prev">
                            </div>
                        </td>
                        <td>
                            <div id="c_sta">
                                <ul>
                                    <li></li>
                                </ul>
                            </div>
                        </td>
                        <td>
                            <div id="next_sta" class="next">
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <uc2:FooterUc ID="FooterUc1" runat="server" />
    <uc3:modal_dialog ID="modal_dialog1" runat="server" />

    </form>
</body>
</html> 