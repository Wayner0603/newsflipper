using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Infonex;
using Infonex.Data ;
using System.Data.SqlClient;

namespace newsflippers {
    public partial class sources : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                this.SourceControlUC1.AddBlankText();
            }
        }

        protected void Button1_Click(object sender, EventArgs e) {
            try {

                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@NPR_PARENT_ID", this.SourceControlUC1.SourceID);
                cmd.Parameters.AddWithValue("@NPR_TITLE", this.txtTitle.Text );
                cmd.Parameters.AddWithValue("@NPR_DESC",this.txtDesc.Text );
                cmd.Parameters.AddWithValue("@NPR_URL",this.txtUrl.Text );
                cmd.Parameters.AddWithValue("@NPR_LANG", "en");

                Database db = new Database();
                db.ExecuteNonQuery("USP_NEWSPAPERS_INSERT", cmd);
                this.Label1.Text = "Successfully inserted!";
                this.SqlDataSource1.DataBind();

            } catch (Exception ex) {
                this.Label1.Text = ex.Message;
                this.Label1.Text = "Failed";
            }
        }
    }
}
