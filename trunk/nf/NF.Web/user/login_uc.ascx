<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="login_uc.ascx.cs" Inherits="newsflippers.user.login_uc" %>
<%@ Register src="../uc/msg_ctrl.ascx" tagname="msg_ctrl" tagprefix="uc1" %>
<script>
    var state = 0;
    function newUser(s) {
        if (s == 0) {
            $("#newUser").show();
            alert($("input[id$='hpNewUser']").val('afds');
        }
    }

    $(document).ready(function() {
    $("input[id$='btnLogin']").click(function() {
            $.ajax({
                type: "POST",
                url: "WebForm1.aspx/GetDate",
                data: "{}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg) {
                    $("#Result").text(msg);
                }
            });
        });
    });
</script>
<div class="m">
    Email<br />
    <asp:TextBox ID="txtEmail" runat="server" Width="306px"></asp:TextBox><br />
    Password<br />
    <asp:TextBox ID="txtPass" TextMode=Password  runat="server" Width="306px"></asp:TextBox><br />
    <div style="display:none" id="newUser">Confirm Password<br /><asp:TextBox ID="txtConfirmPassword" TextMode=Password  runat="server" Width="306px"></asp:TextBox><br /></div>
    <asp:CheckBox ID="chkSignIn" runat="server" Text="Stay sign-in" /><br />
<asp:Button ID="btnLogin" runat="server" Text="Login" />&nbsp;<asp:HyperLink ID="hpNewUser" NavigateUrl="javascript:newUser(0);" runat="server">New User?</asp:HyperLink>
<br />
    <uc1:msg_ctrl ID="msg_ctrl1" runat="server" />
<div id="Result"></div>
</div>