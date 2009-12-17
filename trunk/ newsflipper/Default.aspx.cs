using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace newsflippers {
    public partial class _Default : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                //List<string> items = new List<string>();

                //DataSet ds = NewsManager.GetImages();

                List<CaptureWebPage> capturedWebPages = NewsManager.GetCaptureWebPages();

                string baseUrl = GetBaseURL();
                foreach (CaptureWebPage  cp in capturedWebPages) {
                    cp.ImageName = string.Format("<a href='{1}' target=\"_blank\"><img border=\"0\" src=\"{0}\"   alt=\"test\" /></a>", string.Format("{0}pages/{1}/{2}", baseUrl, DateTime.Now.ToNewsDateTimeFull(), cp.ImageName), cp.Url);
                }

                //foreach (DataRow row in ds.Tables[0].Rows) {
                //    items.Add();
                //}

                //items.Add("<img src=\"http://localhost:1751/pages/e1684f2c-57e6-4854-b0c5-5cf8860149f9.gif\"   alt=\"test\" />");
                //items.Add("<img src=\"http://localhost:1751/pages/4e9b7da3-04d1-4364-8d04-4588fadab9cf.gif\"   alt=\"test\" />");
                //items.Add("<img src=\"http://localhost:1751/pages/d0f226f4-21f4-4786-8179-6a603dd4240c.gif\" alt=\"test\" />");
                //items.Add("<img src=\"http://localhost:1751/pages/03017334-bf45-4124-abea-ea95c89d73ae.gif\"   alt=\"test\" />");
                
                Session["images"] = capturedWebPages ;
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
