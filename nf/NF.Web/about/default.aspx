<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="newsflippers.about._default1" %>

<%@ Register Src="../uc/HeaderUc.ascx" TagName="HeaderUc" TagPrefix="uc1" %>
<%@ Register Src="../uc/FooterUc.ascx" TagName="FooterUc" TagPrefix="uc2" %>
<%@ OutputCache Duration="90" VaryByParam="none" %>
<%@ Register src="../uc/BugFeatureRequestUc.ascx" tagname="BugFeatureRequestUc" tagprefix="uc3" %>
<%@ Register src="../uc/TopBar.ascx" tagname="TopBar" tagprefix="uc4" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Fastest way to read news online</title>
    <meta name="keywords" content="news,srilanka,online news,fastflip,news flipper" />
    <meta name="description" content="Fastest way to read online news." />
    <script type="text/javascript" src="../js/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="../js/global.min.js"></script>
    <script type="text/javascript">
        location.querystring = (function() {
            var queryStringDictionary = {};
            var querystring = decodeURI(location.search);
            if (!querystring) {
                return {};
            }
            querystring = querystring.substring(1);
            var pairs = querystring.split("&");
            for (var i = 0; i < pairs.length; i++) {
                var keyValuePair = pairs[i].split("=");
                queryStringDictionary[keyValuePair[0]]
                = keyValuePair[1];
            }
            queryStringDictionary.toString = function() {
                if (queryStringDictionary.length == 0) {
                    return "";
                }
                var toString = "?";
                for (var key in queryStringDictionary) {
                    toString += key + "=" +
                queryStringDictionary[key];
                }
                return toString;
            };
            return queryStringDictionary;

        })();
        $(document).ready(function() {
            var page = location.querystring["p"];
            var div = location.querystring["d"];

            if (page == null) {
                $("#about_div").load("about.htm");
            } else {
                loadPage(page, div);
            }
        });

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <uc4:TopBar ID="TopBar1" runat="server" />
        <uc1:HeaderUc ID="HeaderUc1" runat="server" />
        <div id="titlebar">More Info</div>
      <div id="container">
      <div id="container_left"><ul>
        <li><a href="javascript:loadPage('about.htm', 'about_div');">About</a></li>
        <li><a href="javascript:loadPage('whats-new.htm', 'whatsnew_div');">What's new</a></li>
        <li><a href="javascript:loadPage('sources.htm', 'sources_div');">Sources</a></li>
        <li><a href="/">« Back to News</a></li>
      </ul></div>
      <div id="container_middle">
            <div id="about_div">
                    Loading...</div>
                <div id="whatsnew_div" style="display: none">
                    Loading...</div>
                <div id="sources_div" style="display: none">
                    Loading...</div>
            </div>
        </div>
        <uc2:FooterUc ID="FooterUc1" runat="server" />
    <uc3:BugFeatureRequestUc ID="BugFeatureRequestUc1" runat="server" />
    
    </form>
</body>
</html>
