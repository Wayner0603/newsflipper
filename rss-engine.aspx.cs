using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skmRss.Engine;
using System.Text;

namespace newsflippers
{
    public partial class rss_engine : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //RssEngine engine = new RssEngine();
            //RssDocument doc = engine.GetDataSource("http://www.dailymirror.lk/DM_BLOG/RSS/NewsRSS.xml");
            //StringBuilder b = new StringBuilder();
            
            //foreach (RssItem  item in doc.Items)
            //{
            //    b.Append(item.Guid + "<br>");
            //}

            //this.Label1.Text = b.ToString();
        }
    }
}
