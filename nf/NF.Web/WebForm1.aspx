<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="newsflippers.WebForm1" %>

<%@ Register src="uc/HeaderUc.ascx" tagname="HeaderUc" tagprefix="uc1" %>

<%@ Register src="uc/msg_ctrl.ascx" tagname="msg_ctrl" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="js/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="js/car.js"></script>
    <script type="text/javascript" src="js/g.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            $("#car").jCarouselLite({
                btnNext: "#next",
                btnPrev: "#prev",
                beforeStart: function (a) {
                    alert("Before animation starts:" + a);
                },
                afterEnd: function (a) {
                    alert("After animation ends:" + a);
                },
                visible: 1,
                scroll: 2
            });
            msg.text('Hey This is cool');

        });
       
    </script>
    <link href="css/skin.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
   <uc2:msg_ctrl ID="msg_ctrl1" runat="server" />
     <div id="prev">
        
        Prev</div>
    <div id="next">
        Next</div>
    <div id="car">
        <ul>
            <li>
               
                <img src='/pages/2010/04/19/_AasM43WyUyjsn2-uQXOCw.gif' /></li>
            <li>
                <img src='/pages/2010/04/19/_AasM43WyUyjsn2-uQXOCw.gif' /></li>
            <li>
                <img src='/pages/2010/04/19/_AasM43WyUyjsn2-uQXOCw.gif' /></li>
            <li>
                <img src='/pages/2010/04/19/_AasM43WyUyjsn2-uQXOCw.gif' /></li>
        </ul>
    </div>
    </form>
</body>
</html>
