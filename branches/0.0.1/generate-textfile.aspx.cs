using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;

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

                string todayFolder = HttpContext.Current.Server.MapPath(string.Format("~/pages/{0}/{1}/{2}", Extensions.ToYear(Extensions.ToLocalDateTime()), Extensions.ToMonth(Extensions.ToLocalDateTime()), Extensions.ToDay(Extensions.ToLocalDateTime())));
                string dateTimeText = Extensions.ToNewsDateTime(Extensions.ToLocalDateTime());
                List<Source> sources = NewsManager.GetSources();
                StringBuilder b = new StringBuilder();
                //if (File.Exists(path))
                //{
                    //System.IO.StreamWriter StreamWriter1 = new System.IO.StreamWriter(path);
                    foreach (Source s in sources)
                    {
                        List<Source> childSourceList = NewsManager.GetChildSources(s);
                        foreach (Source ChildSource in childSourceList)
                        {
                            b.AppendFormat("{0}<br>", Extensions.FormatURL(ChildSource.Url));
                            //StreamWriter1.WriteLine(Extensions.FormatURL(ChildSource.Url));

                        }
                    }
                    this.Label2.Text = b.ToString();

                    
                    //StreamWriter1.Close();
                //}
            }
            catch (Exception ex)
            {
                this.Label1.Text = ex.Message;
            }
            


        }
    }
}
