using System;
using System.Collections.Generic;

using System.Web;

namespace newsflippers
{
    public static class Extensions
    {
        private const string DATE = "<DATE>";

        public static string ToNewsDateTime(DateTime dt)
        {
            return DateTime.Now.ToString("yyyyMMdd");
        }

        public static string ToNewsDateTimeFull(DateTime dt)
        {
            return DateTime.Now.ToString("yyyy/MM/dd");
        }

        public static string ToYear(DateTime dt)
        {
            return DateTime.Now.ToString("yyyy");
        }

        public static string ToMonth(DateTime dt)
        {
            return DateTime.Now.ToString("MM");
        }

        public static string ToDateRef(DateTime dt)
        {
            return DateTime.Now.ToString("MMddyyyy");
        }


        public static string ToDay( DateTime dt)
        {
            return DateTime.Now.ToString("dd");
        }

        public static string ToImageString(string url) {
            url = FormatURL(url);
            return url.Replace("http://www.","").Replace("/","");
        }

        public static string FormatURL(string url)
        {
            string dateTimeText = Extensions.ToNewsDateTimeFull(DateTime.Now);
            if (url.Contains(DATE))
            {
                url = url.Replace(DATE, dateTimeText);
                return url;
            }
            return url;
        }
    }
}
