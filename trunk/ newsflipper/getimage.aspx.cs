using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace newsflippers {
    public partial class getimage : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            Response.Expires = -1;		//required to keep the page from being cached on the client's browser
            //if (Session["count"] == null) {
            //    Session["count"] = "0";
            //} else {
            //    Session["count"] = (Convert.ToInt32(Session["count"]) + 1).ToString();
            //}

            if (Request["r"] == null && string.IsNullOrEmpty(Request["r"])) return;
            int count = Convert.ToInt32(Request["r"]);

            Response.ContentType = "text/plain";

            Response.Write(string.Format("{0};{1};{2};{3}", count.ToString(), ((List<CaptureWebPage>)Session["images"])[count].ImageName, ((List<CaptureWebPage>)Session["images"]).Count.ToString(), ((List<CaptureWebPage>)Session["images"])[count].Url));
            Response.End();
        }
    }
}
