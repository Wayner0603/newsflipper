using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NF.Engine.Facade;
using NF.Engine.Source;
using NF.Engine;

namespace newsflippers {
    public partial class get_view : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            Response.Expires = -1;
            Response.ContentType = "text/plain";

            SourceLogic logic = new SourceLogic();
            string response = string.Empty;

            string url = Util.UrlDecode(Request["type"]);

            string section = string.Empty;
            string source = string.Empty;
            string country = string.Empty;
            string q = string.Empty;

            string[] types = url.Split(';');

            foreach (string item in types) {
                string[] a = item.Split(':');
                if (a[0] == "section") {
                    section = a[1];
                } else if (a[0] == "source") {
                    source = a[1];
                } else if (a[0] == "country") {
                    country = a[1];
                } else if (a[0] == "q") {
                    q = a[1];
                }
            }

            WebPageList webpageList = null;

            if (string.IsNullOrEmpty(q)) {
                if (Cache[Util.GetCacheKey(section, source, country)] == null) {
                    webpageList = logic.GetWebPages(Util.GetDate().ToMonthRef(), section, source, country);
                    Cache[Util.GetCacheKey(section, source, country)] = webpageList;
                } else {
                    webpageList = (WebPageList)Cache[Util.GetCacheKey(section, source, country)];
                }
            } else {
                webpageList = logic.Search(q);
            }

            if (Request["c"] == null && string.IsNullOrEmpty(Request["c"])) return;
            int count = Convert.ToInt32(Request["c"]);
            string baseUrl = Util.GetBaseURL().Trim('/');

            string imgName = Util.FormatImage(Request["imname"]);
            string fragUrl = Request["type"];

            WebPage selWebPage = null;

            if (count == 0) {
                selWebPage = webpageList.Get(imgName);
            } else {
                selWebPage = webpageList[count];
            }
            selWebPage.Src = string.Format("<a href='{0}' target=\"_blank\"><img border=\"0\" src=\"{1}\"   alt=\"Click here to read more...\" /></a>", selWebPage.Url, string.Format("{0}/{1}/{2}", baseUrl, NF.Engine.Util.GetRelativeImageFolder(), selWebPage.ImageName));
            response = string.Format("{0};{1};{2};{3};{4};{5};{6};{7}", count.ToString(), selWebPage.Src, webpageList.Count.ToString(), selWebPage.Url, Util.RemoveImageExt(selWebPage.ImageName), selWebPage.Source, selWebPage.ID, selWebPage.Title);

            Response.Write(response);
            Response.End();
        }
    }
}
