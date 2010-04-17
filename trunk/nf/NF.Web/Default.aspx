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
        function mycarousel_itemLoadCallback(carousel, state) {
            if (state != 'init')
                return;

            j = carousel;
            jQuery.get('get_images.aspx?m=1&cat=top', function(data) {
                mycarousel_itemAddCallback(carousel, carousel.first, carousel.last, data);
            });
        };

        function car3_itemLoadCallback(carousel, state) {
            if (state != 'init')
                return;

            j = carousel;
            jQuery.get('get_images.aspx?m=1&cat=top', function(data) {
                car3_itemAddCallback(carousel, carousel.first, carousel.last, data);
            });
        };

        function mycarousel2_itemLoadCallback(carousel, state) {
            if (state != 'init')
                return;
            j = carousel;
            jQuery.get('get_images.aspx?m=1&cat=top', function(data) {
                mycarousel2_itemAddCallback(carousel, carousel.first, carousel.last, data);
            });
        };

        function mycarousel_itemAddCallback(carousel, first, last, data) {
            var items = data.split('|');
            for (i = 0; i < items.length; i++) {
                carousel.add(i + 1, mycarousel_getItemHTML(items[i]));
            }

            carousel.size(items.length);
        };

        function mycarousel2_itemAddCallback(carousel, first, last, data) {
            var items = data.split('|');
            for (i = 0; i < items.length; i++) {
                carousel.add(i + 1, mycarousel_getItemHTML(items[i]));
            }

            carousel.size(items.length);
        };

        function car3_itemAddCallback(carousel, first, last, data) {
            var items = data.split('|');
            for (i = 0; i < items.length; i++) {
                carousel.add(i + 1, mycarousel_getItemHTML(items[i]));
            }

            carousel.size(items.length);
        };

        function mycarousel_getItemHTML(url) {
            var j = url.split(',');
            return '<a href=view.aspx#' + j[2] + '><img border="0" src="pages/2010/04/15/' + j[0] + '" width="320px" height="350px" alt="' + j[1] + '" /><br><span>' + j[1] + '</span></a>';
        };

        jQuery(document).ready(function() {
        load1();

        $("#car2").hide();
        $("#car3").hide();
        $("#car4").hide();
        $("#car5").hide();
        
            jQuery('#car1').jcarousel({
                itemLoadCallback: mycarousel_itemLoadCallback
            });

            jQuery('#car2').jcarousel({
                itemLoadCallback: mycarousel1_itemLoadCallback
            });

            jQuery('#car3').jcarousel({
                itemLoadCallback: car3_itemLoadCallback
            });
            
           
        });

        function load1() {
            $("#car1").show();
            $("#car2").hide();
            $("#car3").hide();
            $("#car4").hide();
            $("#car5").hide();
            $("#sp1").addClass('menu_selected');
            $("#sp2").removeClass('menu_selected');
            $("#sp3").removeClass('menu_selected');
            $("#sp4").removeClass('menu_selected');
            $("#sp5").removeClass('menu_selected');
        }

        function load2() {
            $("#car1").hide();
            $("#car2").show();
            $("#car3").hide();
            $("#car4").hide();
            $("#car5").hide();
            $("#sp1").removeClass('menu_selected');
            $("#sp2").addClass('menu_selected');
            $("#sp3").removeClass('menu_selected');
            $("#sp4").removeClass('menu_selected');
            $("#sp5").removeClass('menu_selected');
        }

        function load3() {
            $("#car1").hide();
            $("#car2").hide();
            $("#car3").show();
            $("#car4").hide();
            $("#car5").hide();
            $("#sp1").removeClass('menu_selected');
            $("#sp2").removeClass('menu_selected');
            $("#sp3").addClass('menu_selected');
            $("#sp4").removeClass('menu_selected');
            $("#sp5").removeClass('menu_selected');
        }
        
        function load4() {
            $("#car1").hide();
            $("#car2").hide();
            $("#car3").hide();
            $("#car4").show();
            $("#car5").hide();
            $("#sp1").removeClass('menu_selected');
            $("#sp2").removeClass('menu_selected');
            $("#sp3").removeClass('menu_selected');
            $("#sp4").addClass('menu_selected');
            $("#sp5").removeClass('menu_selected');
        }


        function load5() {
            $("#car1").hide();
            $("#car2").hide();
            $("#car3").hide();
            $("#car4").hide();
            $("#car5").show();
            $("#sp1").removeClass('menu_selected');
            $("#sp2").removeClass('menu_selected');
            $("#sp3").removeClass('menu_selected');
            $("#sp4").removeClass('menu_selected');
            $("#sp5").addClass('menu_selected');
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
    <div class="menu_bar"><span id="sp1" class="menu_item" onclick="load1();">Top Stories</span>&nbsp;&nbsp;&nbsp;<span class="menu_item" id="sp2" onclick="load2();">Business</span>&nbsp;&nbsp;&nbsp;<span class="menu_item" id="sp3" onclick="load3();">Sci/Tech</span>&nbsp;&nbsp;&nbsp;<span class="menu_item" id="sp4" onclick="load4();">Entertainment</span>&nbsp;&nbsp;&nbsp;<span class="menu_item" id="sp5" onclick="load5();">Starred</span></div>
   <div id="carousel">
  <div id="car1" class="jcarousel-skin-ie7"> 1
    <ul> 
      <!-- The content will be dynamically loaded in here --> 
    </ul> 
  </div> 
  <div id="car2" class="jcarousel-skin-ie7"> 2
    <ul> 
      <!-- The content will be dynamically loaded in here --> 
    </ul> 
  </div> 
  </div>
  <div id="car3" class="jcarousel-skin-ie7"> 3
    <ul> 
      <!-- The content will be dynamically loaded in here --> 
    </ul> 
  </div> 
   <div id="car4" class="jcarousel-skin-ie7"> 3
    <ul> 
      <!-- The content will be dynamically loaded in here --> 
    </ul> 
  </div> 
   <div id="car5" class="jcarousel-skin-ie7"> 3
    <ul> 
      <!-- The content will be dynamically loaded in here --> 
    </ul> 
  </div> 
  </div>  
</div> 
<uc2:FooterUc ID="FooterUc1" runat="server" />
<uc3:modal_dialog ID="modal_dialog1" runat="server" />

</form>
</body>
</html>
