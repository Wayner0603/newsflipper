<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="email_sender.aspx.cs" Inherits="newsflippers.settings.email_sender" %>
<%@ Register src="../uc/msg_ctrl.ascx" tagname="msg_ctrl" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../css/skin.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="../js/jquery-1.4.2.min.js"></script>
    <script language="javascript" type="text/javascript" src="../js/g.js"></script>
    <title></title>
    <script type="text/javascript">

        function val() {
            var u = $("#<%= txtEmail.ClientID%>");
            var p = $("#<%= txtSub.ClientID%>");
            var filter = /^([a-zA-Z0-9_.-])+@(([a-zA-Z0-9-])+.)+([a-zA-Z0-9]{2,4})+$/;
            if (u.val() == '') {
                msg.val('Email required');
                return false;
            } else if (!filter.test(u.val())) {
                msg.val('Valid email required');
                return false;
            } else if (p.val() == '') {
                msg.val('Subject required');
                return false;
            }
            return true;
        }

        function send() {
            if (val()) {
                $.ajax({
                    type: "POST",
                    url: '/services/SettingsService.asmx/SendEmail',
                    data: "{'email':'" + $("#<%=txtEmail.ClientID %>").val() + "','subject': '" + $("#<%=txtSub.ClientID %>").val() + "', 'body': '" + $("#<%=txtMsg.ClientID %>").val() + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (text) {
                        if (text.d) {
                            msg.suc('Email successfully sent.');
                            setTimeout(function () { parent.modal.c(); }, 1000);
                        } else {
                            msg.err('please try again.');
                        }
                    },
                    error: function (text) {
                        msg.err(text);
                    }
                });
            }
            return false;
        }
    
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div id="login_box">
            Email<br />
            <asp:TextBox ID="txtEmail" runat="server" CssClass="txt" Width="400px"></asp:TextBox>
            <br />
            Subject<br />
            <asp:TextBox ID="txtSub" runat="server" CssClass="txt" Width="400px"></asp:TextBox>
            <br />
            Message<br />
            <asp:TextBox ID="txtMsg" runat="server" CssClass="txt" TextMode="MultiLine" Rows="4"
                Width="400px"></asp:TextBox>
            <br />
            <asp:Button ID="btnSend" runat="server" CssClass="btn" OnClientClick="return send();"
                Text="Send" />&nbsp;<asp:Button ID="btnOK" OnClientClick="return parent.modal.c();" runat="server" CssClass="btn"
            Text="Cancel" />
            <uc1:msg_ctrl ID="msg_ctrl1" runat="server" />
            <br />
        </div>
    </div>

    
    </form>
</body>
</html>
