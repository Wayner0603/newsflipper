using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NF.Core;
using skmRss.Engine;

namespace newsflippers
{
    public partial class rss_test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            RssManager m = new RssManager();
            this.GridView1.DataSource = m.GetRssItems(@"http://news.google.com/news?pz=1&cf=all&ned=us&hl=en&output=rss");
            this.GridView1.DataBind();
        }
    }
}
