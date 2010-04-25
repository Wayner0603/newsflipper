<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="msg_ctrl.ascx.cs" Inherits="newsflippers.uc.msg_ctrl" %>
<script type="text/javascript">
var _time = 10000;
    function _msg() {
        addMethod(this, "suc", function (text) {
            _setMsg(text, 'msg_suc', 0, _time);
        });

        addMethod(this, "err", function (text) {
            _setMsg(text, 'msg_err', 0, _time);
        });

        addMethod(this, "val", function (text) {
            _setMsg(text, 'error', 0, _time);
        });

        addMethod(this, "text", function (text) {
            _setMsg(text, '', 0, _time);
        });

        addMethod(this, "text", function (text, time) {
            _setMsg(text, '', 0, time);
        });

        addMethod(this, "html", function (text) {
            _setMsg(text, '', 1, _time);
        });

        addMethod(this, "html", function (text, time) {
            _setMsg(text, '', 1, time);
        });
    }

    function _setMsg(text, css, isHtml, time) {
        if ($("#message_box").is(":hidden")) {
            $("#message_box").slideDown("fast");
        }
        if (isHtml == 0) {
            $("#message_box").text(text);
        } else {
            $("#message_box").html(text);
        }
        _setMsgLocation();
        setTimeout(function () { $("#message_box").slideUp("fast") }, time);

    }

    function _setMsgLocation() {
        var w = ($(window).width() / 2) - ($("#message_box").width() / 2);
        $("#message_box").css("left", w);
    }

    $(window).scroll(function () {
        $('#message_box').css("top", $(window).scrollTop() + "px")
    });

    $(window).resize(function () {
        $('#message_box').css("top", $(window).scrollTop() + "px")
        _setMsgLocation();
    });

    var msg = new _msg();
</script>
<div id="message_box">
</div>
