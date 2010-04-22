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

        //public WebPageList GetCaptureWebPages() {
        //    return GetCaptureWebPages(Util.GetDate().ToMonthRef());
        //}

        //public WebPageList GetCaptureWebPages(string dt)
        //{
        //    return GetCaptureWebPages(dt, string.Empty );
        //}

        public bool DoStarred(string userId, int itemId, bool isStarred) {
            return DataModel.DoStarred(userId, itemId, isStarred, Util.GetDate());    
        }


        public bool IsStarred(string userId, int itemId) {
            return DataModel.IsStarred(userId, itemId);
        }


        private WebPageList ConverToWebPageList(IDataReader rdr, string section, string source, string country) {
            WebPageList webpageList = new WebPageList();
            while (rdr.Read()) {
                webpageList.Add(new WebPage() {
                    ID = Convert.ToInt32(rdr["ITM_ID"]),
                    Title = rdr["ITM_TITLE"].ToString(),
                    ImageName = rdr["ITM_IMGNAME"].ToString(),
                    ThumbImageName = rdr["ITM_IMGTHUMB"].ToString(),
                    Url = rdr["ITM_URL"].ToString(),
                    Category = rdr["ITM_CAT"].ToString(),
                    Source = rdr["SRC_NAME"].ToString(), Section = rdr["ITM_CAT"].ToString(), Country = rdr["SRC_COUNTRY"].ToString()
                });
            }
            rdr.Close();
            webpageList.WebPageTypes.Add("source", source);
            webpageList.WebPageTypes.Add("section", section);
            webpageList.WebPageTypes.Add("country", country);
            return webpageList;
        }

        public WebPageList GetWebPages(string dateRef, string section, string source, string country) {
            IDataReader rdr = DataModel.GetWebPages(dateRef ,section , source , country );
            WebPageList webpageList = ConverToWebPageList(rdr, section, source, country);
            return webpageList;
        }

        public WebPageList Search(string keyword) {
            IDataReader rdr = DataModel.GetWebPages(keyword);
            WebPageList webpageList = ConverToWebPageList(rdr, string.Empty, string.Empty, string.Empty);
            return webpageList;
        }

        public void InsertSourceItems(DataTable dt) {
            DataModel.InsertSourceItem(dt);
        }
    }
}
