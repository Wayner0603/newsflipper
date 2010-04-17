<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="newsflippers._default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="uc/HeaderUc.ascx" TagName="HeaderUc" TagPrefix="uc1" %>
<%@ Register Src="uc/FooterUc.ascx" TagName="FooterUc" TagPrefix="uc2" %>
<%@ Register src="uc/TopBar.ascx" tagname="TopBar" tagprefix="uc4" %>
<%@ Register src="uc/modal_dialog.ascx" tagname="modal_dialog" tagprefix="uc3" %>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript" src="js/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="js/jspack.js"></script>
    <script type="text/javascript" src="js/jcoursalpack.js"></script>
    <script type="text/javascript" src="js/g.js"></script>
    <script type="text/javascript">
        var j = null;
        var t = ''
        var c_loaded = '0';
        
        var lst = 'top;bus;sci;ent;sta';

        function top_itemLoadCallback(carousel, state) {
            if (state != 'init')
                return;

            jQuery.get('get_images.aspx?m=1&type=top', function(data) {
                mycarousel_itemAddCallback(carousel, carousel.first, carousel.last, data);
            });
        };

        function bus_itemLoadCallback(carousel, state) {
            if (state != 'init')
                return;

            jQuery.get('get_images.aspx?m=1&type=bus', function(data) {
                mycarousel_itemAddCallback(carousel, carousel.first, carousel.last, data);
            });
            $('#bus_d').hide();
        };

        function sci_itemLoadCallback(carousel, state) {
            if (state != 'init')
                return;

            jQuery.get('get_images.aspx?m=1&type=sci', function(data) {
                mycarousel_itemAddCallback(carousel, carousel.first, carousel.last, data);
            });
            $('#sci_d').hide();

        };

        function ent_itemLoadCallback(carousel, state) {
            if (state != 'init')
                return;

            jQuery.get('get_images.aspx?m=1&type=ent', function(data) {
                mycarousel_itemAddCallback(carousel, carousel.first, carousel.last, data);
            });
            $('#ent_d').hide();

        };

        function sta_itemLoadCallback(carousel, state) {
            if (state != 'init')
                return;

            jQuery.get('get_images.aspx?m=1&type=sta', function(data) {
                mycarousel_itemAddCallback(carousel, carousel.first, carousel.last, data);
            });
            $('#sta_d').hide();

        };

        function mycarousel_itemAddCallback(carousel, first, last, data) {
            var items = data.split('|');
            for (i = 0; i < items.length; i++) {
                carousel.add(i + 1, mycarousel_getItemHTML(items[i]));
            }

            carousel.size(items.length);
        };
       
        function mycarousel_getItemHTML(url) {
            var j = url.split(',');
            return '<a href=view.aspx?x:0&type=' + j[3] + '#' + j[2] + '><img border="0" src="' + j[0] + '" width="320px" height="350px" alt="' + j[1] + '" /><br><span>' + j[1] + '</span></a>';
        };

        function load_c(type) {
            set_links(type);
            var l = lst.split(';');
            for (i = 0; i < l.length; i++) {
                if (l[i] != type) {
                    $('#' + l[i] + '_d').hide();
                }
            }
            $('#' + type + '_d').show();
        }
        
        jQuery(document).ready(function() {
                jQuery('#top_j').jcarousel({
                    itemLoadCallback: top_itemLoadCallback
                });

                jQuery('#bus_j').jcarousel({
                    itemLoadCallback: bus_itemLoadCallback
                });

                jQuery('#sci_j').jcarousel({
                    itemLoadCallback: sci_itemLoadCallback
                });

                jQuery('#ent_j').jcarousel({
                    itemLoadCallback: ent_itemLoadCallback
                });

                jQuery('#sta_j').jcarousel({
                    itemLoadCallback: sta_itemLoadCallback
                });
        });

        function set_links(type) {
            var l = lst.split(';');
            for (i = 0; i < l.length; i++) {
                if (l[i] != type) {
                    //$("#" + l[i] + '_d').hide();
                    $("#" + l[i] + '_l').removeClass('menu_selected');
                }
            }
            //$("#" + type + '_d').show();
            $("#" + type + '_l').addClass('menu_selected');
        }

</script> 
<link href="css/skin.css" rel="stylesheet" type="text/css" />
<link href="css/skin_jcoursal.css" rel="stylesheet" type="text/css" />
<link href="App_Themes/Default/skin.css" rel="stylesheet" type="text/css" />

</head>
<body>
<form id="form1" runat="server">
<uc4:TopBar ID="TopBar1" runat="server" />
<uc1:HeaderUc ID="HeaderUc1" runat="server" />
<div id="wrap"> 
    <div class="menu_bar"><span id="top_l" class="menu_item" onclick="load_c('top');">Top Stories</span>&nbsp;&nbsp;&nbsp;<span class="menu_item" id="bus_l" onclick="load_c('bus');;">Business</span>&nbsp;&nbsp;&nbsp;<span class="menu_item" id="sci_l" onclick="load_c('sci');">Sci/Tech</span>&nbsp;&nbsp;&nbsp;<span class="menu_item" id="ent_l" onclick="load_c('ent');">Entertainment</span>&nbsp;&nbsp;&nbsp;<span class="menu_item" id="sta_l" onclick="load_c('sta');">Starred</span></div>
 <div id="carousel">
 
  <div id="top_d">top
  <div id="top_j" class="jcarousel-skin-ie7">
    <ul> 
      <!-- The content will be dynamically loaded in here --> 
    </ul> 
  </div> </div>
  <div id="bus_d" >bus
  <div id="bus_j" class="jcarousel-skin-ie7">
    <ul> 
      <!-- The content will be dynamically loaded in here --> 
    </ul> 
  </div> </div>
  <div id="sci_d" >sci
  <div id="sci_j" class="jcarousel-skin-ie7">
    <ul> 
      <!-- The content will be dynamically loaded in here --> 
    </ul> 
  </div> 
  </div>
  <div id="ent_d" ">ent
   <div id="ent_j" class="jcarousel-skin-ie7">
    <ul> 
      <!-- The content will be dynamically loaded in here --> 
    </ul> 
  </div> 
  </div>
  <div id="sta_d" >sta
   <div id="sta_j" class="jcarousel-skin-ie7">
    <ul> 
      <!-- The content will be dynamically loaded in here --> 
    </ul> 
  </div> </div>
  </div></div>  
<uc2:FooterUc ID="FooterUc1" runat="server" />
<uc3:modal_dialog ID="modal_dialog1" runat="server" />

</form>
</body>
</html>
