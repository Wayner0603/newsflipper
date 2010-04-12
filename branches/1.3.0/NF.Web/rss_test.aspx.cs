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
            //TEst
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //NFEngine.ProcessRss();
            /*RssManager m = new RssManager();
            RssItemList items = m.GetRssItems(@"http://news.google.com/news?pz=1&cf=all&ned=us&hl=en&output=rss");

            foreach (RssItem item in items)
            {
                News.Insert(35, item.Title, item.Description, item.Link, item.Author, item.Category, item.PubDate, DateTime.Now, DateTime.Now.ToString("yyyyMMddHH"), string.Empty);
            }

            this.Label1.Text = "Successfully Installed!";*/

            //NFEngine.ProcessRss();
        }
    }
}
