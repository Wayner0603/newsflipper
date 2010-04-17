<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="msg_ctrl.ascx.cs" Inherits="newsflippers.uc.msg_ctrl" %>

<script type="text/javascript">
    $(document).ready(function() { $("#<%=lblMsg.ClientID%>").fadeOut(20000); });

    function _msg() {
        addMethod(this, "suc", function(text) {
            _setMsg(text, 'success');
        });

        addMethod(this, "err", function(text) {
            _setMsg(text, 'error');
        });

        addMethod(this, "val", function(text) {
            _setMsg(text, 'error');
        });

        addMethod(this, "set", function(text, css) {
            _setMsg(text, css);
        });
    }

    function _setMsg(text, css) {
        $("#<%=lblMsg.ClientID %>").css("display", "inline");
        $("#<%=lblMsg.ClientID %>").addClass(css);
        $("#<%=lblMsg.ClientID %>").text(text);
        $("#<%=lblMsg.ClientID %>").fadeOut(20000);
        return false;
    }
    var msg = new _msg();
</script>
<table cellpadding="0" cellspacing="0" class="msg_outer">
    <tr>
        <td><asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
        </td>
    </tr>
</table>
