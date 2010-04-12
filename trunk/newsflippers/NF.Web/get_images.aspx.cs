using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace newsflippers
{
    public partial class get_images : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Expires = -1;
            Response.ContentType = "text/plain";
            string str = "im1.png,something1,www.google.com|im2.png,something2,www.google.com|im3.png,something3,www.google.com|im4.png,something4,www.google.com|im5.png,something5,www.google.com|im6.png,something6,www.google.com|im1.png,something1,www.google.com|im2.png,something2,www.google.com|im3.png,something3,www.google.com|im4.png,something4,www.google.com|im5.png,something5,www.google.com|im6.png,something6,www.google.com";
            if (Request["r"] != null)
            {
                str = "im4.png,something1,www.google.com|im5.png,something2,www.google.com";
            }
            Response.Write(str);
            Response.End();
        }
    }
}
