<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="report_issues.aspx.cs" Inherits="newsflippers.settings.report_issues" %>
<%@ Register src="../uc/msg_ctrl.ascx" tagname="msg_ctrl" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
 <link href="../css/skin.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="../js/jquery-1.4.2.min.js"></script>
    <script language="javascript" type="text/javascript" src="../js/g.js"></script>
    <script type="text/javascript">
        function selectText() {
            $("#<%=txtIssue.ClientID %>").select();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <div id="login_box">
            <asp:TextBox ID="txtIssue" runat="server"  onclick="selectText();"  CssClass="txt" Rows="4" 
                TextMode="MultiLine" Width="450px" Height="104px"></asp:TextBox>
            <br />
            <asp:Button ID="btnSend" runat="server" CssClass="btn" 
                OnClientClick="return send();" Text="Submit" />&nbsp;<asp:Button ID="btnOK" OnClientClick="return parent.modal.c();" runat="server" CssClass="btn"
            Text="Cancel" />
            <br />
        </div>
    
    </div>
    <uc1:msg_ctrl ID="msg_ctrl1" runat="server" />

    <script type="text/javascript">

        function val() {
            var u = $("#<%= txtIssue.ClientID%>");

            if (u.val() == '') {
                msg.val("Oops! you haven't entered anything");
                return false;
            }
            return true;
        }

        function send() {
            if (val()) {
                $.ajax({
                    type: "POST",
                    url: '/services/SettingsService.asmx/SubmitIssue',
                    data: "{'issue':'" + $("#<%=txtIssue.ClientID %>").val() + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (text) {
                        if (text.d) {
                            msg.suc('Thanks for your support');
                            setTimeout(function () { parent.modal.c(); }, 1000);

                        } else {
                            msg.err('please try again.');
                        }
                        return false;
                    },
                    error: function (text) {
                        msg.err(text);
                    }
                });
            }
            return false;
        }
    
</script>
    </form>
</body>
</html>
