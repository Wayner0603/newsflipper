using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NF.Engine {
    public class Constants {
        public const string DATE_LONG_FORMAT = "dd MM yyyy hh:mm tt";
        public const string DATE_SHORT_FORMAT = "ddMMyyyy";
        public const string DATE_MONTH_REF = "yyyyMMdd";
        
        private const string DATE = "<DATE>";

        /// <summary>
        /// D:\01_PROJECTS\SOURCE\NF\NF.Web\pages\
        /// </summary>
        public const string IMAGE_PATH = @"D:\01_PROJECTS\SOURCE\NF\NF.Web\pages\";
        /// <summary>
        /// /Pages
        /// </summary>
        public const string RELATIVE_IMAGE_PATH = @"pages";

        public const string KEY_SESSION_PAGES  = "__CPAGES";

    }
}
