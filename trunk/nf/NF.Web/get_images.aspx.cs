using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using NF.Engine;
using NF.Engine.Source;

namespace newsflippers {
    public partial class get_images : System.Web.UI.Page {
        string type = string.Empty;
        protected void Page_Load(object sender, EventArgs e) {
            SourceLogic logic = new SourceLogic();

            Response.Expires = -1;
            Response.ContentType = "text/plain";

            string response = string.Empty;

            string url = Request["type"];
            type = url;
            string section = string.Empty;
            string source = string.Empty;
            string country = string.Empty;

            string[] types = url.Split(';');

            foreach (string item in types)
	        {
                string[] a = item.Split(':');
                if(a[0] == "section") {
                    section = a[1];
                }else if (a[0] == "source") {
                    source = a[1];
                } else if (a[0] == "country") {
                    country = a[1];
                }
	        }

            WebPageList webpageList = logic.GetWebPages(Util.GetDate().ToMonthRef(), section, source, country); 

            response = GetResponse(webpageList);

            Response.Write(response);
            Response.End();
        }

        private string GetResponse(WebPageList pages) {
            string response = string.Empty;

            foreach (WebPage item in pages) {
                response += string.Format("{0},{1},{2},{3}|", item.FullThumbnailImagePath, item.Title, Util.RemoveImageExt(item.ImageName), Util.UrlEncode(type));
            }
            return response;
        }
    }
}
