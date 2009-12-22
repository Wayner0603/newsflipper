using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace newsflippers {
    public partial class _Default : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                if (Cache[Utility.GetCacheKey()] != null) return;

                List<CaptureWebPage> capturedWebPages = NewsManager.GetCaptureWebPages();
                if (capturedWebPages.Count == 0) {
                    capturedWebPages = NewsManager.GetCaptureWebPages(Extensions.ToDateRef(Utility.LocalDate().AddDays(-1)));
                }

                string baseUrl = GetBaseURL();
                //this.Label1.Text = string.Format("Date:{0}<br> Links:{1}", Utility.LocalDate().ToString(Utility.DATE_LONG_FORMAT), capturedWebPages.Count.ToString());
                foreach (CaptureWebPage  cp in capturedWebPages) {
                    cp.ImageName = string.Format("<a href='{1}' target=\"_blank\"><img border=\"0\" src=\"{0}\"   alt=\"Click here to read more...\" /></a>", string.Format("{0}pages/{1}/{2}", baseUrl, Extensions.ToNewsDateTimeFull(Utility.LocalDate()), cp.ImageName), cp.Url);
                }

                Cache[Utility.GetCacheKey()] = capturedWebPages ;
            }
        }

        private string GetBaseURL (){
            string Port = Request.ServerVariables["SERVER_PORT"];
            if (Port == null || Port == "80" || Port == "443")
                Port = "";
            else
                Port = ":" + Port;

            string Protocol = Request.ServerVariables["SERVER_PORT_SECURE"];
            if (Protocol == null || Protocol == "0")
                Protocol = "http://";
            else
                Protocol = "https://";


            // *** Figure out the base Url which points at the application's root
            string path = Protocol + Request.ServerVariables["SERVER_NAME"] +
                                        Port + Request.ApplicationPath;

            return path;
        }
    }
}
