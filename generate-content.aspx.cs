using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace newsflippers {
    public partial class generate_content : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            
        }

        protected void Button1_Click(object sender, EventArgs e) {
            /*DataSet ds = NewsManager.GetNewsLinks();
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0) {
                foreach (DataRow row in ds.Tables[0].Rows) {
                    WebsitesScreenshot.WebsitesScreenshot _WebsitesScreenshot = new WebsitesScreenshot.WebsitesScreenshot();
                    WebsitesScreenshot.WebsitesScreenshot.Result _Result;
                    string path = null;
                    path = Server.MapPath(".");
                    //_WebsitesScreenshot.ImageHeight = 768;
                    _WebsitesScreenshot.BrowserWidth = 1000;
                    _WebsitesScreenshot.BrowserHeight = 700;
                    _WebsitesScreenshot.ImageFormat = WebsitesScreenshot.WebsitesScreenshot.ImageFormats.GIF;
                    _WebsitesScreenshot.JpegQuality = 50;

                    _Result = _WebsitesScreenshot.CaptureWebpage(row["NPR_URL"].ToString());
                    if (_Result == WebsitesScreenshot.WebsitesScreenshot.Result.Captured) {
                        string imageName = Guid.NewGuid().ToString() + ".gif";
                        string fullImageName = path + string.Format("\\pages\\{0}", imageName);
                        _WebsitesScreenshot.SaveImage(fullImageName);
                        NewsManager.InsertImage(Convert.ToInt32("1"), imageName);
                        Response.Write("Done!");
                    }
                    _WebsitesScreenshot.Dispose();
                }
            }*/
        }
    }
}
