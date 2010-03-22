﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace newsflippers
{
    public partial class data_insert : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string todayFolder = HttpContext.Current.Server.MapPath(string.Format("~/pages/{0}/{1}/{2}", Extensions.ToYear(Extensions.ToLocalDateTime()), Extensions.ToMonth(Extensions.ToLocalDateTime()), Extensions.ToDay(Extensions.ToLocalDateTime())));
           //string todayFolder = HttpContext.Current.Server.MapPath("~/pages/2009/12/21");//, Extensions.ToYear(Extensions.ToLocalDateTime()), Extensions.ToMonth(Extensions.ToLocalDateTime()), Extensions.ToDay(Extensions.ToLocalDateTime())));
           string dateTimeText = Extensions.ToNewsDateTime(Extensions.ToLocalDateTime());
            List<Source> sources = NewsManager.GetSources();
            this.Label2.Text = dateTimeText + "<br>" + todayFolder;
            int count = 0;
            foreach (Source s in sources)
            {
                List<Source> childSourceList = NewsManager.GetChildSources(s);
                foreach (Source ChildSource in childSourceList)
                {
                    string imgName= Extensions.ToImageString(ChildSource.Url);
                    if(IsImageExists(imgName)) {
                        if (!NewsManager.IsImageExists(imgName + ".gif"))
                        {
                            NewsManager.InsertImage(ChildSource.ID, imgName + ".gif", "", Extensions.FormatURL(ChildSource.Url.ToString()));
                            count++;
                        }
                    }
                }
            }

            this.Label1.Text = string.Format("{0} inserted!", count.ToString());

        }

        private bool IsImageExists(string imageName) {
            string todayFolder = HttpContext.Current.Server.MapPath(string.Format("~/pages/{0}/{1}/{2}/", Extensions.ToYear(Extensions.ToLocalDateTime()), Extensions.ToMonth(Extensions.ToLocalDateTime()), Extensions.ToDay(Extensions.ToLocalDateTime())));
            //string todayFolder = HttpContext.Current.Server.MapPath("~/pages/{0/{1}/{2}/");//, Extensions.ToYear(Extensions.ToLocalDateTime()), Extensions.ToMonth(Extensions.ToLocalDateTime()), Extensions.ToDay(Extensions.ToLocalDateTime())));
            return File.Exists(todayFolder + imageName + ".gif");
        }
    }
}