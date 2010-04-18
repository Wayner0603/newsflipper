using System;
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
        }
        public static string FormatURL(string url) {
            //string dateTimeText = Extensions.ToNewsDateTimeFull(Util.GetDate());
            //if (url.Contains(DATE)) {
            //    url = url.Replace(DATE, dateTimeText);
            //    return url;
            //}
            return url;
        }

        public static string FormatImage(string blankImgName) {
            return string.Format("{0}.gif", blankImgName);
        }

        public static string RemoveImageExt(string imgName) {
            return imgName.Replace(".gif", "");
        }

        public static string RemoveReservedChar(string text) {
            return text.Replace(":", "");
        }

        public static string GetImageFolder() {
            return string.Format(@"{0}2010\04\17\", Constants.IMAGE_PATH);
            //return string.Format(@"{3}{0}\{1}\{2}\", Util.GetDate().ToYear(), Util.GetDate().ToMonth(), Util.GetDate().ToDay(), Constants.IMAGE_PATH);
        }

        public static string UrlEncode(string url) {
            return HttpContext.Current.Server.UrlEncode(url);
        }

        public static string UrlDecode(string url) {
            return HttpContext.Current.Server.UrlDecode(url);
        }

        /// <summary>
        /// /Pages/2010/04/17
        /// </summary>
        /// <returns></returns>
        public static string GetRelativeImageFolder()
        {
            return string.Format(@"{3}/{0}/{1}/{2}", Util.GetDate().ToYear(), Util.GetDate().ToMonth(), Util.GetDate().ToDay(), Constants.RELATIVE_IMAGE_PATH);
            //return string.Format(@"{0}/2010/04/17", Constants.RELATIVE_IMAGE_PATH);
        }

        public static string ToCategories(string type) {
            string cat = string.Empty;
            switch (type)
            {
                case "top":
                    cat = "Top Stories";
                    break;
                case "bus":
                    cat = "Business";
                    break;
                case "sci":
                    cat = "Sci/Tech";
                    break;
                case "ent":
                    cat = "Entertainment";
                    break;
               
            }
            return cat;
        }


        public static string GetCacheKey(string section, string source, string country) {
            return string.Format("{0}_{1}_{2}", Util.UrlEncode(section), Util.UrlEncode(source), Util.UrlEncode(country));
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
