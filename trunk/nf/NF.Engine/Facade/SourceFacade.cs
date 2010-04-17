using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NF.Engine.Source;
using System.Data;
using System.Web;

namespace NF.Engine.Facade {
    public class SourceFacade {
        public static DataTable GetSourceItems() {
            SourceLogic logic = new SourceLogic();
            return logic.GetNewsItems();
        }

        public static void InsertSourceItems(DataTable dt) {
            SourceLogic logic = new SourceLogic();
            logic.InsertSourceItems(dt);
        }
        public static void LoadPages(string date) {
            if (HttpContext.Current.Cache[Constants.KEY_SESSION_PAGES] == null) {
                SourceLogic logic = new SourceLogic();
                PageList pages = logic.GetCaptureWebPages(date);
                HttpContext.Current.Cache[Constants.KEY_SESSION_PAGES] = pages;
            }
        }

        //public static List<CaptureWebPage> GetCapturedWebPages(string date) {
        //    return GetCapturedWebPages(date, string.Empty);
        //}

        public static PageList  GetPage(string date, string cat) {
            PageList cPages = (PageList)HttpContext.Current.Cache[Constants.KEY_SESSION_PAGES];
            PageList selpages = cPages.GetAll(cat);
            return selpages;
        }
    }
}
