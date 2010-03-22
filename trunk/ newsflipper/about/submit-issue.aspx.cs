﻿using System;
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
            string request = "";
            if (Request["issue"] != null && !string.IsNullOrEmpty(Request["issue"])) { request = Request["issue"]; }
            string content = string.Empty;
            try
            {
                NewsManager.InsertIssue("issue");
                content = "Thank you for your submission.";
            }
            catch (Exception ex)
            {
                content = "Unable to process the request.";
            }

            Response.ContentType = "text/plain";
            Response.Write(content);
            Response.End();
        }
    }
}