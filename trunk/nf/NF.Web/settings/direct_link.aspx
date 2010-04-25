<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="direct_link.aspx.cs" Inherits="newsflippers.settings.direct_link" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/skin.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="../js/jquery-1.4.2.min.js"></script>
    <script language="javascript" type="text/javascript" src="../js/g.js"></script>
    <script language="javascript">
        function selectText() {
            $("#<%=txtLink.ClientID %>").select();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="wrapper">
        <asp:TextBox ID="txtLink" CssClass="txt" runat="server" onclick="selectText();" Width="450px"></asp:TextBox><br />
        <br />
        <asp:Button ID="btnOK" OnClientClick="return parent.modal.c();" runat="server" CssClass="btn"
            Text="Okay" />

    </div>
    </form>
</body>
</html>
