﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace NF.Engine {
    public class Util {
        public static DateTime GetDate() {
            string timespanstr = "5:30"; //ConfigurationSettings.AppSettings["LocalTime"];
            char[] c = { ':' };
            string hr = timespanstr.Split(c)[0];
            string min = timespanstr.Split(c)[1];

            TimeSpan s = new TimeSpan(Convert.ToInt32(hr), Convert.ToInt32(min), 0);
            return DateTime.UtcNow.Add(s);
            //return DateTime.Now;
        }
        public static string FormatURL(string url) {
            //string dateTimeText = Extensions.ToNewsDateTimeFull(Util.GetDate());
            //if (url.Contains(DATE)) {
            //    url = url.Replace(DATE, dateTimeText);
            //    return url;
            //}
            return url;
        }

        public static string GetImageFolder() {
            //return string.Empty;
            return string.Format(@"{3}{0}\{1}\{2}\", Util.GetDate().ToYear(), Util.GetDate().ToMonth(), Util.GetDate().ToDay(),Constants.IMAGE_PATH);
        }

        public static string GetCacheKey() {
            return string.Empty;
            
        }

        public static string GetPreviousCacheKey() {
            return string.Empty;
        }

        public static string GetBaseURL() {
            string Port = HttpContext.Current.Request.ServerVariables["SERVER_PORT"];
            if (Port == null || Port == "80" || Port == "443")
                Port = "";
            else
                Port = ":" + Port;

            string Protocol = HttpContext.Current.Request.ServerVariables["SERVER_PORT_SECURE"];
            if (Protocol == null || Protocol == "0")
                Protocol = "http://";
            else
                Protocol = "https://";


            // *** Figure out the base Url which points at the application's root
            string path = Protocol + HttpContext.Current.Request.ServerVariables["SERVER_NAME"] +
                                        Port + HttpContext.Current.Request.ApplicationPath;

            return path;
        }


    }
}
