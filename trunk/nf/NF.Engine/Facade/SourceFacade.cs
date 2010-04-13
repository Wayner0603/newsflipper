using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NF.Engine.Source;
using System.Data;

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

        public static List<CaptureWebPage> GetCapturedWebPages(string date) {
            SourceLogic logic = new SourceLogic();
            return logic.GetCaptureWebPages(date);
        }
    }
}
