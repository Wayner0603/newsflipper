using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace NF.Engine
{
    public static class Extensions
    {
        //private const string DATE = "<DATE>";

        //public static string ToNewsDateTime(DateTime dt)
        //{
        //    return dt.ToString("yyyyMMdd");
        //}

        public static string ToImagePath(this DateTime dt)
        {
            return dt.ToString("yyyy/MM/dd");
            //return dt.ToString("2010/04/15");
        }

        public static string ToYear(this DateTime dt)
        {
            return dt.ToString("yyyy");
        }

        public static string ToMonth(this DateTime dt)
        {
            return dt.ToString("MM");
        }

        public static string ToDay(this DateTime dt)
        {
            return dt.ToString("dd");
        }

        //public static string ToDateRef(DateTime dt)
        //{
        //    return dt.ToString("MMddyyyy");
        //}

        public static string ToMonthRef(this DateTime dt) {
            return "20100417";
            //return dt.ToString(Constants.DATE_MONTH_REF); 
        }

       

        //public static string ToImageString(string url)
        //{
        //    url = FormatURL(url);
        //    return url.Replace("http://www.", "").Replace("/", "");
        //}

        //public static string FormatURL(string url)
        //{
        //    string dateTimeText = Extensions.ToNewsDateTimeFull(NFEngine.LocalDate());
        //    if (url.Contains(DATE))
        //    {
        //        url = url.Replace(DATE, dateTimeText);
        //        return url;
        //    }
        //    return url;
        //}

        //public static DateTime ToLocalDateTime()
        //{
        //    return ToLocalDateTime(DateTime.UtcNow);
        //}

        //public static DateTime ToLocalDateTime(DateTime dt)
        //{
        //    string timespanstr = ConfigurationSettings.AppSettings["LocalTime"];
        //    char[] c = { ':' };
        //    string hr = timespanstr.Split(c)[0];
        //    string min = timespanstr.Split(c)[1];

        //    TimeSpan s = new TimeSpan(Convert.ToInt32(hr), Convert.ToInt32(min), 0);
        //    return dt.Add(s);
        //}
    }
}
