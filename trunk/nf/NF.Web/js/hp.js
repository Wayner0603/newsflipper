
function call_signin() {
    modal.show('/user/', 'Sign in to Newsflipper Account', 500, 320);
}

function call_directlink(link) {
    modal.show('/settings/direct_link.aspx?lnk=' + link, 'Direct Link to this page', 500, 150);
}

function call_email(title, link) {
    modal.show('/settings/email_sender.aspx?title=' + title + "&lnk=" + link, 'Email', 500, 350);
}

function call_issues() {
    modal.show('/settings/report_issues.aspx', 'Please send your issues or suggestions.', 550, 300);
}

function _menu() {
    addMethod(this, "nav", function (url, sTab, oTabs, sTabCss, oTabCss) {
        _nav(url, sTab, oTabs, sTabCss, oTabCss);
    });

    addMethod(this, "nav", function (url, sTab, oTabs) {
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
