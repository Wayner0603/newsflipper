﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="newsflippers._default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <script type="text/javascript" src="js/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="js/global.min.js"></script>

    <script type="text/javascript">
var j = null;
function mycarousel_itemLoadCallback(carousel, state)
{
    // Since we get all URLs in one file, we simply add all items
    // at once and set the size accordingly.
    if (state != 'init')
        return;
    j = carousel;
    jQuery.get('get_images.aspx', function(data) {
        mycarousel_itemAddCallback(carousel, carousel.first, carousel.last, data);
    });
};

function mycarousel2_itemLoadCallback(carousel, state) {
    // Since we get all URLs in one file, we simply add all items
    // at once and set the size accordingly.
    if (state != 'init')
        return;
    j = carousel;
    jQuery.get('get_images.aspx?r=u', function(data) {
        mycarousel2_itemAddCallback(carousel, carousel.first, carousel.last, data);
    });
};
 
function mycarousel_itemAddCallback(carousel, first, last, data)
{
    // Simply add all items at once and set the size accordingly.
    //var t = 'images/home.gif|images/import.gif|images/left-arrow.gif|images/logout_new.png'
    var items = data.split('|');
    for (i = 0; i < items.length; i++) {
        carousel.add(i+1, mycarousel_getItemHTML(items[i]));
    }
 
    carousel.size(items.length);
};

function mycarousel2_itemAddCallback(carousel, first, last, data) {
    // Simply add all items at once and set the size accordingly.
    //var t = 'images/home.gif|images/import.gif|images/left-arrow.gif|images/logout_new.png'
    var items = data.split('|');
    for (i = 0; i < items.length; i++) {
        carousel.add(i + 1, mycarousel_getItemHTML(items[i]));
    }

    carousel.size(items.length);
};
 
/**
 * Item html creation helper.
 */
function mycarousel_getItemHTML(url) {
    var j = url.split(',');
    return '<a href="' + j[2] + '"><img border="0" src="images/' + j[0] + '" width="320px" height="350px" alt="' + j[1] + '" /><br><span>' + j[1] + '</span></a>';
};

jQuery(document).ready(function() {
  
    jQuery('#mycarousel').jcarousel({
            itemLoadCallback: mycarousel_itemLoadCallback
        });

//    jQuery('#mycarousel2').jcarousel({
//        itemLoadCallback: mycarousel2_itemLoadCallback
//    });
    $("#mycarousel2").hide();
});

function loadtop() {
    $("#mycarousel").show();
    $("#mycarousel2").hide();
//    jQuery('#mycarousel2').jcarousel({
//        itemLoadCallback: mycarousel2_itemLoadCallback
//    });
}

var loaded = 0;
function loadcnn() {
    $("#mycarousel").hide();
    $("#mycarousel2").show();

    if (loaded == 0) {
        jQuery('#mycarousel2').jcarousel({
            itemLoadCallback: mycarousel2_itemLoadCallback
        });
        loaded = 1;
    }
}

</script> 
    <link href="css/skin.css" rel="stylesheet" type="text/css" />
    <link href="css/skin_jcoursal.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="wrap"> 
    <span onclick="loadtop();">Top Stories</span> | <span onclick="loadcnn();">CNN</span>
  <div id="mycarousel" class="jcarousel-skin-ie7"> 
    <ul> 
      <!-- The content will be dynamically loaded in here --> 
    </ul> 
  </div> 
  <div id="mycarousel2" class="jcarousel-skin-ie7"> 
    <ul> 
      <!-- The content will be dynamically loaded in here --> 
    </ul> 
  </div> 
  
</div> 
    </form>
</body>
</html>
