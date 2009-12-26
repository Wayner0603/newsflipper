using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace newsflippers.about
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            try
            {
                NewsManager.InsertIssue(this.TextBox1.Text);
                this.lblMsg.Text = "Thanks for submitting your issue/feature.";
                this.lblMsg.CssClass = "success";
            }
            catch (Exception ex)
            {
                this.lblMsg.CssClass = "error";
                this.lblMsg.Text = ex.Message;// "Opps, error ocurred!";
            }
        }
    }
}
