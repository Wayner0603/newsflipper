<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="newsflippers.user._default" %>
<%@ OutputCache Duration="6000" Location="Server" VaryByParam="*" %>


<%@ Register src="login_uc.ascx" tagname="login_uc" tagprefix="uc1" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <script type="text/javascript" src="../js/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="../js/g.js"></script>
    
    <link href="../css/skin.css" rel="stylesheet" type="text/css" />
    
</head>
<body>
    <form id="form1" runat="server">
    <uc1:login_uc ID="login_uc1" runat="server" />
    
    </form>
</body>
</html>
