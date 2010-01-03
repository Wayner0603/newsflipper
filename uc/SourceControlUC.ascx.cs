using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace newsflippers.uc {
    public partial class SourceControlUC : System.Web.UI.UserControl {

        public string SourceName {
            get {
                return this.DropDownList1.SelectedItem.Text;
            }
        }

        public string SourceID {
            get {
                return this.DropDownList1.SelectedValue;
            }
        }

        public Source SelectedSource {
            get {
                return NewsManager.GetSource(Convert.ToInt32(this.DropDownList1.SelectedValue));
            }
        }


        public void AddBlankText() {
            this.DropDownList1.Items.Insert(0, new ListItem("", "0"));
        }

        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                this.DropDownList1.DataTextField = "Title";
                this.DropDownList1.DataValueField= "ID";
                this.DropDownList1.DataSource = NewsManager.GetSources();
                this.DropDownList1.DataBind();
            }
        }
    }
}