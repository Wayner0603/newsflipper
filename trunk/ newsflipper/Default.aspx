<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="newsflippers._default" %>

<%@ Register src="uc/HeaderUc.ascx" tagname="HeaderUc" tagprefix="uc1" %>

<%@ Register src="uc/FooterUc.ascx" tagname="FooterUc" tagprefix="uc2" %>

<%@OutputCache Duration="90" VaryByParam="none" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Flip through your news everyday - It's fast and easy</title>
<style type="text/css"> 
 
#mycarousel.jcarousel-container-horizontal {
    width: 900px;
    height: 800px;
}
 
#mycarousel .jcarousel-clip-horizontal {
    border: 1px solid #ccc;
    width: 900px;
    height: 800px;
}
 
#mycarousel .jcarousel-item,
#mycarousel .jcarousel-item-placeholder {
    width: 900px;
    height: 800px;
}
 
#mycarousel .jcarousel-item-horizontal img {
}
 
#mycarousel .jcarousel-item-horizontal p {
    margin: 5px;
    text-align: left;
    clear: both;
    white-space: wrap;
}
 
#mycarousel .jcarousel-item-placeholder {
    background: transparent url(../images/loading.gif) 50% 50% no-repeat;
}
 
#mycarousel .jcarousel-next {
    top: 150px;
    right: -55px;
}
 
#mycarousel .jcarousel-prev {
    top: 150px;
    left: 10px;
}
 
#mycarousel form {
    margin-top: 10px;
}
 
#mycarousel form label,
#mycarousel form small {
    display: block;
}
 
</style>   
  
    <script type="text/javascript" src="js/jquery-1-3-2.js"></script>
    <script type="text/javascript" src="js/jCarousel.js"></script>
    <script type="text/javascript"> 
 
var mycarousel_tags = '';
var c = 0;
var totalcount = -1;

function mycarousel_initCallback(carousel, state)
{
    // Do nothing of state is 'reset'
    if (state == 'reset')
        return;
 
    jQuery('form', carousel.container)
    .bind('submit', function(e) {
        mycarousel_tags = jQuery('input[@type=text]', carousel.container).val();
        carousel.reset();
        return false;
    });
    
};
 
function mycarousel_itemLoadCallback(carousel, state) {
    // Only load items if they don't already exist
    if (carousel.has(carousel.first, carousel.last)) {
        return;
    }
    if (totalcount == c) {
        c = c - 1;
        carousel.prev();
        return;
    }
    
    jQuery.get("getimage.aspx?r=" + c, function(response) {
        carousel.add(response.split(';')[0], response.split(';')[1]);
        totalcount = response.split(';')[2];
        //$("Label1").innerText = response.split(';')[3];
    });
    c = c + 1;
//    jQuery.get(
//        'dynamic_flickr_feed.php',
//        {
//            tags: mycarousel_tags
//        },
//        function(data) {
//        mycarousel_itemAddCallback(carousel, carousel.first, carousel.last, data);
//        },
//        'json'
//    );
};
 
 
//function mycarousel_itemAddCallback(carousel, first, last, data)
//{
//    if (first == 1) {
//        var plural = data.length == 1 ? '' : 's';
//        jQuery('.results', carousel.container).html(data.length + ' photo' + plural + ' found');
// 
//        // Set size
//        if (data.length == 0) {
//            // Add a "no results" feedback as first item if data is empty
//            carousel.size(1);
//            carousel.add(1, '<p>No results</p>');
//            return;
//        } else {
//            carousel.size(data.length);
//        }
//    }
// 
//    for (var i = first; i <= last; i++) {
//        if (data[i - 1] == undefined) {
//            break;
//        }

//        carousel.add(i, '<img src="http://localhost:1815/image1.png" width="75" height="75" alt="test" />');
//    }
//};
 
/**
 * Decodes entites.
 */
function mycarousel_decodeEntities(s)
{
    return s.replace(/&amp;/g,  "&")
            .replace(/&quot;/g, '"')
            .replace(/&#039;/g, "'")
            .replace(/&lt;/g,   "<")
            .replace(/&gt;/g,   ">");
};
 
/**
 * This function is needed for the flickr feed.
 */
function jsonFlickrFeed(o)
{
    return o.items;
};
 
jQuery(document).ready(function() {
    jQuery('#mycarousel').jcarousel({
        scroll: 1,
        animation: 200,
        initCallback: mycarousel_initCallback,
        itemLoadCallback: mycarousel_itemLoadCallback
    });
});

</script> 
   
    <link href="css/carousel.css" rel="stylesheet" type="text/css" />
    <link href="css/skin-carousel.css" rel="stylesheet" type="text/css" />
   
</head>
<body>
    <form id="form1" runat="server">
    <%--<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>--%>
    <uc1:HeaderUc ID="HeaderUc1" runat="server" />
    <div id="container">
   <div id="mycarousel" class="jcarousel-skin-ie7"> 
    <ul> 
      <!-- The content will be dynamically loaded in here --> 
        
    </ul> 
   
  </div> </div>
    <uc2:FooterUc ID="FooterUc1" runat="server" />
    </form>
    <script type="text/javascript">
        var gaJsHost = (("https:" == document.location.protocol) ? "https://ssl." : "http://www.");
        document.write(unescape("%3Cscript src='" + gaJsHost + "google-analytics.com/ga.js' type='text/javascript'%3E%3C/script%3E"));
</script>
<script type="text/javascript">
    try {
        var pageTracker = _gat._getTracker("UA-254993-16");
        pageTracker._trackPageview();
    } catch (err) { }</script>
</body>
</html>