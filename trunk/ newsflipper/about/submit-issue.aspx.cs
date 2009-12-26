using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace newsflippers.about
{
    public partial class submit_issue : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Expires = -1;

            if (Request["issue"] == null && string.IsNullOrEmpty(Request["issue"])) return;
            string content = string.Empty;
            try
            {
                NewsManager.InsertIssue("issue");
                content = "success";
            }
            catch (Exception ex)
            {
                content = "success";
            }

            Response.ContentType = "text/plain";
            Response.Write(content);
            Response.End();
        }
    }
}
