using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using NF.Engine.Source;
using NF.Engine;

namespace newsflippers.services {

    [System.Web.Script.Services.ScriptService]
    public class SourceService : System.Web.Services.WebService {

        [WebMethod]
        public string GetResponse(string type) {
            SourceLogic logic = new SourceLogic();

            string response = string.Empty;

            string section = string.Empty;
            string source = string.Empty;
            string country = string.Empty;

            string[] types = Util.UrlDecode(type).Split(';');

            foreach (string item in types) {
                string[] a = item.Split(':');
                if (a[0] == "section") {
                    section = a[1];
                } else if (a[0] == "source") {
                    source = a[1];
                } else if (a[0] == "country") {
                    country = a[1];
                }
            }

            WebPageList webpageList = logic.GetWebPages(Util.GetDate().ToMonthRef(), section, source, country);

            response = "<ul>";
            foreach (WebPage item in webpageList) {
                response += string.Format("<li><a href='view/?{0}#{1}'><img class='thumb' src='{2}' alt='' /><br><span class='thumb_title'>{3}</span></a></li>", Util.UrlEncode(type),Util.RemoveImageExt(item.ImageName), item.FullThumbnailImagePath, item.Title);
            }
            return response+"</ul>";
        }
    }
}
