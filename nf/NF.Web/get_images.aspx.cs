using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NF.Engine;
using NF.Engine.Facade ;

namespace newsflippers
{
    public partial class get_images : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Expires = -1;
            Response.ContentType = "text/plain";
            
            string response = string.Empty;

            if (Request["m"] != null) {
                List<CaptureWebPage> webpages = SourceFacade.GetCapturedWebPages(Util.GetDate().ToMonthRef());

                string mode = Request["m"];
                if (mode == "1") {
                    string type = Request["cat"];
                    if(type == "top") {
                        response = GetResponse(webpages);
                    
                        //response = "im1.png,something1,www.google.com|im2.png,something2,www.google.com|im3.png,something3,www.google.com|im4.png,something4,www.google.com|im5.png,something5,www.google.com|im6.png,something6,www.google.com|im1.png,something1,www.google.com|im2.png,something2,www.google.com|im3.png,something3,www.google.com|im4.png,something4,www.google.com|im5.png,something5,www.google.com|im6.png,something6,www.google.com";
                    } else 
                    {
                        response = GetResponse(webpages);
                        //response = "im4.png,something1,www.google.com|im5.png,something2,www.google.com|im1.png,something1,www.google.com|im1.png,something1,www.google.com|im1.png,something1,www.google.com";
                    }
                    
                } else if (mode == "2") {
                    if (Request["c"] == null && string.IsNullOrEmpty(Request["c"])) return;
                    int count = Convert.ToInt32(Request["c"]);
                    string baseUrl = Util.GetBaseURL();

                    webpages[count].Src = string.Format("<a href='{1}' target=\"_blank\"><img border=\"0\" src=\"{0}\"   alt=\"Click here to read more...\" /></a>", string.Format("{0}pages/{1}/{2}", baseUrl, Util.GetDate().ToImagePath(), webpages[count].ImageName), webpages[count].Url);
                    response = string.Format("{0};{1};{2};{3};{4}", count.ToString(), webpages[count].Src, webpages.Count.ToString(), webpages[count].Url, webpages[count].ImageName);
                }
            }
            
            Response.Write(response);
            Response.End();
        }

        private string GetResponse(List<CaptureWebPage> pages) {
            string response = string.Empty;

            foreach (CaptureWebPage item in pages)
            {
                response += string.Format("{0},{1},{2}|", item.ThumbImageName, item.Title, item.ImageName);
            }
            return response;
        }
    }
}
