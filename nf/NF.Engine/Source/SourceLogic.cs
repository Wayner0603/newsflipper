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

        public PageList GetCaptureWebPages() {
            return GetCaptureWebPages(Util.GetDate().ToMonthRef());
        }

        public PageList GetCaptureWebPages(string dt)
        {
            return GetCaptureWebPages(dt, string.Empty );
        }

        public PageList GetCaptureWebPages(string dt, string cat) {
            PageList childSources = new PageList();
            IDataReader rdr = DataModel.GetCaptureWebPages(dt, cat);
            while (rdr.Read()) {
                childSources.Add(new CaptureWebPage() {
                    Title = rdr["ITM_TITLE"].ToString(),
                    ImageName = rdr["ITM_IMGNAME"].ToString(),
                    ThumbImageName = rdr["ITM_IMGTHUMB"].ToString(),
                    Url = rdr["ITM_URL"].ToString(),
                    Category = rdr["ITM_CAT"].ToString()
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
