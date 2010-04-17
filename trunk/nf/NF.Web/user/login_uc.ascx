<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="login_uc.ascx.cs" Inherits="newsflippers.user.login_uc" %>
<%@ Register src="../uc/msg_ctrl.ascx" tagname="msg_ctrl" tagprefix="uc1" %>
    <uc1:msg_ctrl ID="msg_ctrl1" runat="server" />
<div class="wrapper">
    Email<br />
    <asp:TextBox ID="txtEmail" runat="server" Width="306px"></asp:TextBox><br />
    Password<br />
    <asp:TextBox ID="txtPass" TextMode=Password  runat="server" Width="306px"></asp:TextBox><br />
    <div style="display:none" id="newUser">Confirm Password<br /><asp:TextBox ID="txtConfirmPassword" TextMode=Password  runat="server" Width="306px"></asp:TextBox><br /></div>
    <asp:CheckBox ID="chkSignIn" runat="server" Text="Stay sign-in" /><br />
<asp:Button ID="btnLogin" runat="server" OnClientClick="return auth();" Text="Login" />&nbsp;<asp:HyperLink ID="hpNewUser" NavigateUrl="javascript:newUser();" runat="server">New User?</asp:HyperLink>
<br />

</div>
<script type="text/javascript">
    var nu = 0;
    function newUser() {
        if (nu == 0) {
            nu = 1;
            $("#newUser").show();
            $("#<%=hpNewUser.ClientID %>").text('Sign in');
            $("#<%= btnLogin.ClientID%>").val('Register');
        } else {
        $("#newUser").hide();
        $("#<%= btnLogin.ClientID%>").val('Sign in');
        $("#<%=hpNewUser.ClientID %>").text('Register');
        nu = 0;
        }
    }

    function val() {
        var u = $("#<%= txtEmail.ClientID%>");
        var p = $("#<%= txtPass.ClientID%>");
        var pm = $("#<%= txtConfirmPassword.ClientID%>");
        var filter = /^([a-zA-Z0-9_.-])+@(([a-zA-Z0-9-])+.)+([a-zA-Z0-9]{2,4})+$/;
        
        if (u.val() == '' || !filter.test(u.val())) {
            msg.val('Valid email required');
            return false;
        } else if (p.val() == '') {
            msg.val('Password required');
            return false;
        } else if ((p.val() != pm.val()) && (nu == 1)) {
            msg.val('Password mismatch');
            return false;
        }

        return true;
    }

    function auth() {
        if (val()) {
            $.ajax({
                type: "POST",
                url: '/services/UserService.asmx/Authenticate',
                data: "{'mode':'" + nu + "','email': '" + $("input[id$='txtEmail']").val() + "', 'password': '" + $("input[id$='txtPass']").val() + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(text) {
                    if (text.d) {
                        parent.location.href = "/";
                    } else {
                        msg.err('Please try again later');
                    }
                    return false;
                },
                error: function(text) {
                    msg.err(text);
                }
            });
        }
        return false;
    }
    
</script>