using System;
using System.Collections.Generic;
using System.Web;
using System.Configuration;

namespace newsflippers
{
    public class Utility
    {
        public static string DATE_LONG_FORMAT = "dd MM yyyy hh:mm tt";
        public static string DATE_SHORT_FORMAT = "ddMMyyyy";
        private const string DATE = "<DATE>";

        public static DateTime LocalDate() {
            string timespanstr = ConfigurationSettings.AppSettings["LocalTime"];
            char[] c = { ':' };
            string hr = timespanstr.Split(c)[0];
            string min = timespanstr.Split(c)[1];

            TimeSpan s = new TimeSpan(Convert.ToInt32(hr), Convert.ToInt32(min), 0);
            return DateTime.UtcNow.Add(s);
        }

        public static string GetCacheKey() {
            return string.Format("links_{0}", LocalDate().ToString(DATE_SHORT_FORMAT));
        }

        public static string GetPreviousCacheKey()
        {
            return string.Format("links_{0}", LocalDate().AddDays(-1).ToString(DATE_SHORT_FORMAT));
        }

        public static string GetImageFolder() {
            return string.Format("~/pages/{0}/{1}/{2}/", Extensions.ToYear(Utility.LocalDate()), Extensions.ToMonth(Utility.LocalDate()), Extensions.ToDay(Utility.LocalDate()));
        }

        public static string ToImageString(string url)
        {
            url = FormatURL(url);
            return url.Replace("http://www.", "").Replace("/", "");
        }

        public static string FormatURL(string url)
        {
            string dateTimeText = Extensions.ToNewsDateTimeFull(LocalDate());
            if (url.Contains(DATE))
            {
                url = url.Replace(DATE, dateTimeText);
                return url;
            }
            return url;
        }
    }
}
