using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace newsflippers {
    public static class Extensions {

        public static string ToNewsDateTime(this DateTime dt) {
            return DateTime.Now.ToString("yyyyMMdd");
        }

        public static string ToNewsDateTimeFull(this DateTime dt) {
            return DateTime.Now.ToString("yyyy/MM/dd");
        }

        public static string ToYear(this DateTime dt) {
            return DateTime.Now.ToString("yyyy");
        }

        public static string ToMonth(this DateTime dt) {
            return DateTime.Now.ToString("MM");
        }

        public static string ToDay(this DateTime dt) {
            return DateTime.Now.ToString("dd");
        }
    }
}
