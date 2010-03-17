using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace newsflippers {
    public partial class getimage : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            Response.Expires = -1;	

            if (Request["r"] == null && string.IsNullOrEmpty(Request["r"])) return;
            int count = Convert.ToInt32(Request["r"]);

            Response.ContentType = "text/plain";
            List<CaptureWebPage> webpages = (List<CaptureWebPage>)Cache[Utility.GetCacheKey()];

            Response.Write(string.Format("{0};{1};{2};{3}", count.ToString(), webpages[count].ImageName, webpages.Count.ToString(), webpages[count].Url));
            Response.End();
        }
    }
}
