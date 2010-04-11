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
                if (Request["admin"] != null) {
                    InsertData();
                    Response.Redirect("~/default.aspx");
                }
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

        private void InsertData() {
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

        protected void Button2_Click(object sender, EventArgs e)
        {
            InsertData();

        }
        private string GetValue(int i)
        {
            if (i < 10)
            {
                return string.Format("0{0}", i.ToString());
            }
            return i.ToString();
        }

        private bool IsImageExists(string imageName)
        {
            string todayFolder = HttpContext.Current.Server.MapPath(Utility.GetImageFolder());
            return File.Exists(todayFolder + imageName + ".gif");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string path = Server.MapPath("~") + @"\pages\";
            for (int i = 2010; i <= 2012; i++)
            {
                Directory.CreateDirectory(path + GetValue(i));
                for (int j = 1; j <= 12; j++)
                {
                    string path1 = string.Format(@"{0}{1}\{2}", path, GetValue(i), GetValue(j));
                    Directory.CreateDirectory(path1);
                    for (int x = 1; x <= 31; x++)
                    {
                        string path2 = string.Format(@"{0}{1}\{2}\{3}", path, GetValue(i), GetValue(j), GetValue(x));
                        Directory.CreateDirectory(path2);
                    }
                }
            }
        }
    }
}
