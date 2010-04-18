using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NF.Engine;

namespace newsflippers.uc {
    public partial class search_uc : System.Web.UI.UserControl {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                if (Request.Url.ToString().Contains("?")) {
                    string q = Request.Url.ToString().Substring(Request.Url.ToString().IndexOf("?") + 1);
                    this.txtKeyword.Text = Util.UrlDecode(q);
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e) {
            string url = "~/search/?" + Util.UrlEncode(Util.RemoveReservedChar(txtKeyword.Text));
            Response.Redirect(url);
        }
    }
}