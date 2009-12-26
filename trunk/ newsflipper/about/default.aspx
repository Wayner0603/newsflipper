﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="newsflippers.about._default" %>

<%@ Register src="../uc/HeaderUc.ascx" tagname="HeaderUc" tagprefix="uc1" %>

<%@ Register src="../uc/FooterUc.ascx" tagname="FooterUc" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <script type="text/javascript" src="js/jquery-1-3-2.js"></script>
<script>
    function submit() {
        jQuery.get("submit-issue.aspx?issue=my issue", function(response) {
            alert(response);
        });
        return false;
    }
</script>

</head>
<body>
    <form id="form1" runat="server">
    <uc1:HeaderUc ID="HeaderUc1" runat="server" />
    <div id="leftmenu">
        <asp:HyperLink CssClass="link" ID="HyperLink2" runat="server" 
            NavigateUrl="~/about/default.aspx">About Newsflippers</asp:HyperLink><br />
        <asp:HyperLink CssClass="link" ID="HyperLink1" runat="server" 
            NavigateUrl="~/about/default.aspx">Report an Issue</asp:HyperLink><br />
    </div><div id="middlecontent"><h3>About Newsflippers.com</h3>
        Newsflippers.com site is completly generated by a list of selected news sources. 
            It has been noted that most of the online news readers waste immense amount of 
            time just by waiting the page to load yet struggling to find the relvent news to 
            them. Newsflippers.com −&nbsp;Make you flip through your news just like you 
        flipping through a newspaper hence making your online news reading simple, fast 
        and effective. Newsflippers.com is not just another news web site, it&#39;s a total 
        new experience. It&#39;s fast, easy and no local fonts required. 
        <h3>How it works ?</h3>
        Newsflippers.com site is generating webpage images from the news sources and 
            arranging them accordingly. Currently it&#39;s supporting only selected news 
            sources.&nbsp; 
        <br />
        <br />
        Report an Issue or suggest a new feature<br />
        <asp:TextBox CssClass="textbox" ID="TextBox1" runat="server" Height="71px" TextMode="MultiLine" 
            Width="558px"></asp:TextBox>
        <br /><br />
        <asp:LinkButton ID="LinkButton1" CssClass="btn" runat="server" 
            onclick="LinkButton1_Click"><span><span>Submit</span></span></asp:LinkButton>
        &nbsp;<asp:Label ID="lblMsg" runat="server"></asp:Label>
        <br />
    </div><br /><br /><br /><br /><div class="footer-border">
    <uc2:FooterUc ID="FooterUc1" runat="server" />
    </div></form>
</body>
</html>
