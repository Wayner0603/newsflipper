<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="modal_dialog.ascx.cs"
    Inherits="newsflippers.uc.modal_dialog" %>

<script language="javascript" type="text/javascript">
    function addMethod(object, name, fn) {
        var old = object[name];
        object[name] = function() {
            if (fn.length == arguments.length)
                return fn.apply(this, arguments);
            else if (typeof old == 'function')
                return old.apply(this, arguments);
        };
    }
    
    function modalDialog() {
        addMethod(this, "show", function(url) {
        _show(url, 600, 400);
        });
        addMethod(this, "show", function(url, width, height) {
            _show(url,width, height);
        });
    }

    function _show(url, width, height) {
        $("#modalDialog").width(width);
        $("#modalDialog").height(height);
            
        showPanel();
        showCarousel(0);
        setSearchPanelLocation();

        $("#modalDialog").show();
        var frame = document.getElementById('modalIFrame');
        if (frame.src != url) {
            document.getElementById('modalIFrame').src = url;

        }
        return false;
    }
    
    var modal = new modalDialog();
    
    function setSearchPanelLocation() {
        var w = ($(window).width() / 2) - ($("#modalDialog").width() / 2);
        $("#modalDialog").css("left", w);
    }

    function showPanel() {
        $("#overlay").show();
        $("#overlay").width($(document).width());
        $("#overlay").height($(document).height());

    }

    function showCarousel(v) {
        if (v == 0) {
            $("#carousel").hide();

        } else {
            $("#carousel").show();
        }
    }

//    function showModal(url, width, height) {
//        showModal(url, 600, 400);
//    }

    //        function showModal(url, width,height)
    //        {
    //           
    //        }

    function closeModal() {
        $("#overlay").hide();
        showCarousel(1);
        $("#modalDialog").hide();

    }
</script>

<div id="overlay" class="overlay_div" style="background-color: #000">
</div>
<div id="modalDialog" class='modal_outer' style="display: none;">
    <div class='modal_frame'>
        <div onclick="closeModal();" class="modal_header">
            <img src="../images/close.gif" /></div>
        <iframe src='' id="modalIFrame" style="background-color: #fff" frameborder="0" width="100%"
            height="100%"></iframe>
    </div>
</div>
