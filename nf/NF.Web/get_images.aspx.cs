using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls ;
using System.Web.UI.WebControls;
using NF.Engine;
using NF.Engine.Facade ;

namespace newsflippers
{
    public partial class get_images : System.Web.UI.Page
    {
        string type = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Expires = -1;
            Response.ContentType = "text/plain";
            
            string response = string.Empty;

            if (Request["m"] != null) {
                SourceFacade.LoadPages(Util.GetDate().ToMonthRef());
                type = Request["type"];
                
                PageList webpages = SourceFacade.GetPage(Util.GetDate().ToMonthRef(), type);

                string mode = Request["m"];
                
                if (mode == "1") {
                    response = GetResponse(webpages);


                } else if (mode == "2") {

                    if (Request["c"] == null && string.IsNullOrEmpty(Request["c"])) return;
                    int count = Convert.ToInt32(Request["c"]);
                    string baseUrl = Util.GetBaseURL().Trim('/');

                    string imgName = Request["imname"];
                    //webpages[count].Src = string.Format("<a href='{0}' target=\"_blank\"><img border=\"0\" src=\"{1}\"   alt=\"Click here to read more...\" /></a>", webpages[count].Url, string.Format("{0}/{1}/{2}", baseUrl, NF.Engine.Util.GetRelativeImageFolder(), webpages[count].ImageName));

                    string fragUrl = Request["type"];

                    PageList ps = webpages.GetAll(fragUrl.Split(':')[0], fragUrl.Split(':')[1]);
                    CaptureWebPage selWebPage = ps[count];

                    //if (Request.Url.ToString().Contains("x:0")) {
                    //    selWebPage = webpages.Get(imgName);
                    //} else {
                    //    selWebPage = webpages[count];
                    //}

                    selWebPage.Src = string.Format("<a href='{0}' target=\"_blank\"><img border=\"0\" src=\"{1}\"   alt=\"Click here to read more...\" /></a>", selWebPage.Url, string.Format("{0}/{1}/{2}", baseUrl, NF.Engine.Util.GetRelativeImageFolder(), selWebPage.ImageName));
                    
                    response = string.Format("{0};{1};{2};{3};{4}", count.ToString(), selWebPage.Src, webpages.Count.ToString(), selWebPage.Url, selWebPage.ImageName);
                }
            }
            
            Response.Write(response);
            Response.End();
        }

        private string GetResponse(PageList pages) {
            string response = string.Empty;

            foreach (CaptureWebPage item in pages)
            {
                response += string.Format("{0},{1},{2},{3}|", item.FullThumbnailImagePath, item.Title, item.ImageName, Util.UrlEncode(type));
            }
            return response;
        }
    }
}
