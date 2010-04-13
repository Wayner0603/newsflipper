using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using NF.Engine.Common;
using NF.Engine.Source;

namespace NF.Engine.Source {
    public class SourceLogic : LogicBase<SourceData> {
        public DataTable GetNewsItems() {
            return DataModel.GetNewsItems();
        }

        public List<CaptureWebPage> GetCaptureWebPages() {
            return GetCaptureWebPages(Util.GetDate().ToMonthRef());
        }

        public List<CaptureWebPage> GetCaptureWebPages(string dt) {
            List<CaptureWebPage> childSources = new List<CaptureWebPage>();
            IDataReader rdr = DataModel.GetCaptureWebPages(dt);
            while (rdr.Read()) {
                childSources.Add(new CaptureWebPage() {
                    Title = rdr["ITM_TITLE"].ToString(),
                    ImageName = rdr["ITM_IMGNAME"].ToString(),
                    Url = rdr["ITM_URL"].ToString()
                });
            }
            rdr.Close();
            return childSources;
        }

        public void InsertSourceItems(DataTable dt) {
            DataModel.InsertSourceItem(dt);
        }
    }
}
