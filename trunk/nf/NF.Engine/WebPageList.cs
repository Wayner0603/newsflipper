using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NF.Engine {
    public class WebPageList : List<WebPage> {

        private WebPageTypeList _WebPageTypes = new WebPageTypeList();
        public WebPageTypeList  WebPageTypes {
            get {
                return _WebPageTypes;
            }
            set {
                _WebPageTypes = value;
            }
        }

        public WebPage Get(string imgName) {
            return base.Find(delegate(WebPage p) { return p.ImageName == imgName; });
        }

        //public WebPageList GetAll(string cat) {
        //    return GetAll("section", cat);
        //}

        //public WebPageList GetAll(string type, string cat) {
        //    List<WebPage> list = base.FindAll(delegate(WebPage p) { return p.Category.ToLower() == cat.ToLower() && p.Type.ToLower() == type.ToLower(); });
        //    WebPageList pl = new WebPageList();
        //    for (int i = 0; i < list.Count; i++) {
        //        pl.Add(list[i]);
        //    }
        //    return pl;
        //}
    }
}
