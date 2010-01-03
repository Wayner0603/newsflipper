using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace newsflippers {
    public partial class process_sources : System.Web.UI.Page {

        private const string DATE = "<DATE>";

        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void Button1_Click(object sender, EventArgs e) {

            string dateTimeText = Extensions.ToNewsDateTime(Extensions.ToLocalDateTime());

            List<Source> sourceList = NewsManager.GetChildSources(this.SourceControlUC1.SelectedSource);

            if (sourceList.Count == 0) return;

            CreateDirectory();
            
            int count = 0;
            foreach (Source s in sourceList) {
                WebsitesScreenshot.WebsitesScreenshot _WebsitesScreenshot = new WebsitesScreenshot.WebsitesScreenshot();
                WebsitesScreenshot.WebsitesScreenshot.Result _Result;
                string path = null;
                path = Server.MapPath(".");
                //_WebsitesScreenshot.ImageHeight = 768;
                _WebsitesScreenshot.BrowserWidth = 950;
                _WebsitesScreenshot.BrowserHeight = 800;
                _WebsitesScreenshot.ImageFormat = WebsitesScreenshot.WebsitesScreenshot.ImageFormats.GIF;
                _WebsitesScreenshot.JpegQuality = 50;

                _Result = _WebsitesScreenshot.CaptureWebpage(FormatURL(s.Url.ToString()));
                if (_Result == WebsitesScreenshot.WebsitesScreenshot.Result.Captured) {
                    string imageName = Guid.NewGuid().ToString() + ".gif";
                    string fullImageName = path + string.Format("\\pages\\{0}\\{1}", Extensions.ToNewsDateTimeFull(DateTime.Now), imageName);
                    _WebsitesScreenshot.SaveImage(fullImageName);
                    NewsManager.InsertImage(Convert.ToInt32("1"), imageName, "", FormatURL(s.Url.ToString()));
                    count++;
                }
                _WebsitesScreenshot.Dispose();
                this.Label1.Text = string.Format("{0} succeeded!", count.ToString());
            }
        }

        private void CreateDirectory() {
            if (!Directory.Exists(Server.MapPath(string.Format("~/pages/{0}", Extensions.ToYear(DateTime.Now))))) {
                Directory.CreateDirectory(Server.MapPath(string.Format("~/pages/{0}", Extensions.ToYear(DateTime.Now))));
            }

            if (!Directory.Exists(Server.MapPath(string.Format("~/pages/{0}/{1}", Extensions.ToYear(DateTime.Now), Extensions.ToMonth(DateTime.Now)))))
            {
                Directory.CreateDirectory(Server.MapPath(string.Format("~/pages/{0}/{1}", Extensions.ToYear(DateTime.Now), Extensions.ToMonth(DateTime.Now))));
            }

            if (!Directory.Exists(Server.MapPath(string.Format("~/pages/{0}/{1}/{2}", Extensions.ToYear(DateTime.Now), Extensions.ToMonth(DateTime.Now), Extensions.ToDay(DateTime.Now)))))
            {
                Directory.CreateDirectory(Server.MapPath(string.Format("~/pages/{0}/{1}/{2}", Extensions.ToYear(DateTime.Now), Extensions.ToMonth(DateTime.Now), Extensions.ToDay(DateTime.Now))));
            }
        }

        private string FormatURL(string url) {
            string dateTimeText = Extensions.ToNewsDateTimeFull(DateTime.Now);
            if (url.Contains(DATE)) {
                url = url.Replace(DATE, dateTimeText);
                return url;
            }
            return url;
        }
    }
}
