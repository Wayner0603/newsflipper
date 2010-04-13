using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NF.Engine;

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
                string mode = Request["m"];
                if (mode == "1") {
                    string type = Request["cat"];
                    if(type == "top") {
                    response = "im1.png,something1,www.google.com|im2.png,something2,www.google.com|im3.png,something3,www.google.com|im4.png,something4,www.google.com|im5.png,something5,www.google.com|im6.png,something6,www.google.com|im1.png,something1,www.google.com|im2.png,something2,www.google.com|im3.png,something3,www.google.com|im4.png,something4,www.google.com|im5.png,something5,www.google.com|im6.png,something6,www.google.com";
                    } else {
                        response = "im4.png,something1,www.google.com|im5.png,something2,www.google.com|im1.png,something1,www.google.com|im1.png,something1,www.google.com|im1.png,something1,www.google.com";
                    }
                    
                } else if (mode == "2") {
                    if (Request["c"] == null && string.IsNullOrEmpty(Request["c"])) return;
                    int count = Convert.ToInt32(Request["c"]);

                    List<CaptureWebPage> webpages = (List<CaptureWebPage>)Cache[Util.GetCacheKey()];
                    response = string.Format("{0};{1};{2};{3}", count.ToString(), webpages[count].ImageName, webpages.Count.ToString(), webpages[count].Url);
                }
            }
            
            Response.Write(response);
            Response.End();
        }
    }
}
