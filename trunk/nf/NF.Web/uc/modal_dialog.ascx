<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="modal_dialog.ascx.cs"
    Inherits="newsflippers.uc.modal_dialog" %>
<div id="overlay" class="modal_overlay" style="background-color: #000">
</div>
<div id="modal_outer" style="display: none;">
    <div id='modal_frame'>
        <table cellpadding="0" id="modal_title" cellspacing="0">
            <tr>
                <td >
                    <div id="modalTitle" >
                    </div>
                </td>
                <td class="set_right">
                    <div class="modal_close set_righ" onclick="modal.c();"></div> 
                </td>
            </tr>
        </table><div id="modal_iframe">
    <iframe src='' id="modalIFrame" style="background-color: #fff" frameborder="0" width="100%"
        height="100%"></iframe></div> </div>  
</div>
