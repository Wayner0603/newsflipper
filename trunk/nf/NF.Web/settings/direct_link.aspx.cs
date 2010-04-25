using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NF.Engine;

namespace newsflippers.settings {
    public partial class direct_link : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                if (Request["lnk"] != null && !string.IsNullOrEmpty(Request["lnk"])) {
                    this.txtLink.Text = Util.UrlDecode(Request["lnk"]);
                } 
            }
        }
    }
}