function addMethod(object, name, fn) {
    var old = object[name];
    object[name] = function() {
        if (fn.length == arguments.length)
            return fn.apply(this, arguments);
        else if (typeof old == 'function')
            return old.apply(this, arguments);
    };
}

function _util() {
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

    addMethod(this, "toggleClass", function (div, class1, class2) {
        if ($(div).hasClass(class1)) {
            $(div).removeClass(class1)
            $(div).addClass(class2);
        } else {
            $(div).removeClass(class2)
            $(div).addClass(class1);
        }

    });
}
var util = new _util();


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
    util.hide('#overlay');
    $("body").css("overflow", "");
    util.hide('#modal_outer');
        sCor(1);
    });

    addMethod(this, "showHtml", function (html, title, width, height) {
        _showHtml(html, title, width, height);
    });

}

function overlay_resize() {
    
}

function _showHtml(html, title, width, height) {
    _showCore(title, width, height);
    $(".modal_title").hide();
    $("#f").html(html);
    return false;
}

function _showCore(title, width, height) {
    $("#modal_outer").width(width);
    $("#modal_outer").height(height+18);
    var h = height ;

    $("#modal_frame").height(h);
    $("#modal_iframe").height(h-48);
    
    $("#modalTitle").text(title);
    
    util.show("#overlay");
    $("body").css("overflow", "hidden");

    $("#overlay").width($(window).width());
    $("#overlay").height($(window).height());

    sCor(0);
    util.setLoc('#modal_outer');

    util.show("#modal_outer");
}

function _show(url, title, width, height) {
    _showCore(title, width, height);

    var frame = document.getElementById('modalIFrame');
    if (frame.src != url) {
        document.getElementById('modalIFrame').src = url;
    }
    return false;
}

function sCor(v) {
    if (v == 0) {
        util.hide("#carousel");

    } else {
        util.show("#carousel");
    }
}

var modal = new modalDialog();

function call_signin() {
    modal.show('/user/', 'Sign in to Newsflipper Account', 500, 320);
}

function call_directlink(link) {
    modal.show('/settings/direct_link.aspx?lnk=' + link, 'Direct Link to this page', 500, 150);
}

function call_email(title, link) {
    modal.show('/settings/email_sender.aspx?title=' + title + "&lnk=" + link, 'Email', 500, 350);
}


