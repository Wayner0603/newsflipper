using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NF.Engine;

namespace newsflippers.settings {
    public partial class email_sender : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                if ((Request["lnk"] != null && !string.IsNullOrEmpty(Request["lnk"]))
                    && (Request["title"] != null && !string.IsNullOrEmpty(Request["title"]))) {
                    this.txtSub.Text  = Util.UrlDecode(Request["title"]);
                    this.txtMsg.Text = string.Format("Hi, \r\nYou might be interested in the following article. \r\n{0}", Util.UrlDecode(Request["lnk"]));
                }
            }
        }
    }
}