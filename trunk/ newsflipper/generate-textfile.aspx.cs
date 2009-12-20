using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace newsflippers
{
    public partial class generate_textfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string path = Server.MapPath("~/pages/Sources.txt");

                string todayFolder = HttpContext.Current.Server.MapPath(string.Format("~/pages/{0}/{1}/{2}", Extensions.ToYear(DateTime.Now), Extensions.ToMonth(DateTime.Now), Extensions.ToDay(DateTime.Now)));
                string dateTimeText = Extensions.ToNewsDateTime(DateTime.Now);
                List<Source> sources = NewsManager.GetSources();

                if (File.Exists(path))
                {
                    System.IO.StreamWriter StreamWriter1 = new System.IO.StreamWriter(path);
                    foreach (Source s in sources)
                    {
                        List<Source> childSourceList = NewsManager.GetChildSources(s);
                        foreach (Source ChildSource in childSourceList)
                        {
                            StreamWriter1.WriteLine(Extensions.FormatURL(ChildSource.Url));

                        }
                    }
                    StreamWriter1.Close();
                }
            }
            catch (Exception ex)
            {
                this.Label1.Text = ex.Message;
            }
            


        }
    }
}
