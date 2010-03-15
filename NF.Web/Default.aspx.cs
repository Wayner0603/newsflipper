using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace newsflippers
{
    public partial class default_new : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Expires = -1;
            if (!IsPostBack)
            {
                string cacheKey = Utility.GetCacheKey();
                if (Cache[cacheKey] != null) return;

                DateTime dt = Utility.LocalDate();

                List<CaptureWebPage> capturedWebPages = NewsManager.GetCaptureWebPages();
                if (capturedWebPages.Count == 0)
                {
                    dt = Utility.LocalDate().AddDays(-1);
                    cacheKey = Utility.GetPreviousCacheKey();
                    capturedWebPages = NewsManager.GetCaptureWebPages(Extensions.ToDateRef(dt));
                }

                string baseUrl = GetBaseURL();
                //this.Label1.Text = string.Format("Date:{0}<br> Links:{1}", Utility.LocalDate().ToString(Utility.DATE_LONG_FORMAT), capturedWebPages.Count.ToString());
                foreach (CaptureWebPage cp in capturedWebPages)
                {
                    cp.ImageName = string.Format("<a href='{1}' target=\"_blank\"><img border=\"0\" src=\"{0}\"   alt=\"Click here to read more...\" /></a>", string.Format("{0}pages/{1}/{2}", baseUrl, Extensions.ToNewsDateTimeFull(dt), cp.ImageName), cp.Url);
                }

                Cache[cacheKey] = capturedWebPages;
            }
        }

        private string GetBaseURL()
        {
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
