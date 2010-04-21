<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="modal_dialog.ascx.cs"
    Inherits="newsflippers.uc.modal_dialog" %>
    <script language=javascript >
    $(window).resize(function() {
    
});
    </script>
<div id="overlay" class="overlay_div" style="background-color: #000">
</div>
<div id="modalDialog" class='modal_outer' style="display: none;">
    <div class='modal_frame'>
        <table cellpadding="0" class="modal_title" cellspacing="0">
            <tr>
                <td >
                    <div id="modalTitle" >
                    </div>
                </td>
                <td class="a_right">
                    <img class="modal_close" onclick="modal.c();" src="../images/close.gif" />
                </td>
            </tr>
        </table>
    <iframe src='' id="modalIFrame" style="background-color: #fff" frameborder="0" width="100%"
        height="100%"></iframe>    </div>

</div>
