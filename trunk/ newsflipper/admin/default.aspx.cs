using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;

namespace newsflippers.admin
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                this.Label1.Text = Utility.LocalDate().ToString(Utility.DATE_LONG_FORMAT);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                List<Source> sources = NewsManager.GetAllSources();
                StringBuilder b = new StringBuilder();
                int count = 0;
                foreach (Source s in sources)
                {
                        b.AppendFormat("{0}<br>", Extensions.FormatURL(s.Url));
                        count++;
                }
                this.lblMsg.Text = string.Format("{0} links", count.ToString());
                this.Label2.Text = b.ToString();
                
            }
            catch (Exception ex)
            {
                this.lblMsg.Text = ex.Message;
            }
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string todayFolder = HttpContext.Current.Server.MapPath(Utility.GetImageFolder());
            string dateTimeText = Extensions.ToNewsDateTime(Utility.LocalDate());

            List<Source> sources = NewsManager.GetAllSources();

            int count = 0;
            
            foreach (Source s in sources)
            {
                    string imgName = Extensions.ToImageString(s.Url);
                    if (IsImageExists(imgName))
                    {
                        if (!NewsManager.IsImageExists(imgName + ".gif"))
                        {
                            NewsManager.InsertImage(s.ID, imgName + ".gif", "", Utility.FormatURL(s.Url.ToString()));
                            count++;
                        }
                    }
            }

            this.lblMsg.Text = string.Format("{0} inserted!", count.ToString());

        }

        private bool IsImageExists(string imageName)
        {
            string todayFolder = HttpContext.Current.Server.MapPath(Utility.GetImageFolder());
            return File.Exists(todayFolder + imageName + ".gif");
        }
    }
}
