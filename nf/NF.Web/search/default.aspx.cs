using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NF.Engine;
using NF.Engine.Source;

namespace newsflippers.search {
    public partial class _default : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                if (Request.Url.ToString().Contains("?")) {
                    SourceLogic logic = new SourceLogic();
                    string q = Request.Url.ToString().Substring(Request.Url.ToString().IndexOf("?") + 1);
                    WebPageList pageList = logic.Search(q);
                    this.__Q.Value = q;
                    this.DataList1.DataSource = pageList;
                    this.DataList1.DataBind();
                }
            }
        }

        public string GetUrl(object imgName) {
            return string.Format("{0}view?q:{1}#{2}",Util.GetBaseURL(), Util.UrlEncode(this.__Q.Value ),Util.RemoveImageExt(imgName.ToString()));
        }
      
    }
}
