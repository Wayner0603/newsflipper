﻿function addMethod(object, name, fn) {
    var old = object[name];
    object[name] = function() {
        if (fn.length == arguments.length)
            return fn.apply(this, arguments);
        else if (typeof old == 'function')
            return old.apply(this, arguments);
    };
}

function util() {
    addMethod(this, "hide", function(ctrl) {
        $(ctrl).hide();

    });

    addMethod(this, "show", function(ctrl) {
        $(ctrl).show();

    });

    addMethod(this, "setLoc", function(ctrl) {
        var w = ($(window).width() / 2) - ($(ctrl).width() / 2);
        $(ctrl).css("left", w);

    });

    addMethod(this, "load", function(page) {
        if ($.trim($("#" + div).text()) == 'Loading...') {
            $("#" + div).load(page);
        } else {
        }

        $("#" + div).css("display", "inline");
        if (div == 'sources_div') {
            $("#whatsnew_div").css("display", "none");
            $("#about_div").css("display", "none");
        } else if (div == 'whatsnew_div') {
            $("#sources_div").css("display", "none");
            $("#about_div").css("display", "none");
        } else if (div == 'about_div') {
            $("#sources_div").css("display", "none");
            $("#whatsnew_div").css("display", "none");
        }
        window.location.hash = page;
    });


}
var ur = new util();


jQuery.fn.encHTML = function() {
    var xx = ''
    this.each(function() {
        var me = jQuery(this);
        var html = me.html();

        xx = html.replace(/&/g, '&amp;').replace(/</g, '&lt;').replace(/>/g, '&gt;');
    });
    return xx;
};


function _menu() {
    addMethod(this, "nav", function(url, sTab, oTabs, sTabCss, oTabCss) {
        _nav(url, sTab, oTabs, sTabCss, oTabCss);
    });

    addMethod(this, "nav", function(url, sTab, oTabs) {
        _nav(url, sTab, oTabs, 'nav_item_selected', 'nav_item');
    });

}

function _nav(url, sTab, oTabs, sTabCss, oTabCss) {

    var m = oTabs.split(";");
    for (i = 0; i < m.length; i++) {
        document.getElementById(m[i]).className = oTabCss;
    }
    document.getElementById(sTab).className = sTabCss;
}

var menu = new _menu();


function modalDialog() {
    addMethod(this, "show", function(url, title) {
        _show(url, title, 600, 400);
    });
    addMethod(this, "show", function(url, title, width, height) {
        _show(url, title, width, height);
    });

    addMethod(this, "c", function() {
        ur.hide('#overlay');
        ur.hide('#modalDialog');
        sCor(1);
    });

}



function _show(url, title, width, height) {
    $("#modalDialog").width(width);
    $("#modalDialog").height(height);
    $("#modalTitle").text(title);

    ur.show("#overlay");
    $("#overlay").width($(document).width());
    $("#overlay").height($(document).height());

    sCor(0);
    ur.setLoc('#modalDialog');

    ur.show("#modalDialog");

    var frame = document.getElementById('modalIFrame');
    if (frame.src != url) {
        document.getElementById('modalIFrame').src = url;

    }
    return false;
}

function sCor(v) {
    if (v == 0) {
        ur.hide("#carousel");

    } else {
        ur.show("#carousel");
    }
}

var modal = new modalDialog();

