﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NF.Core;
namespace newsflippers.uc
{
    public partial class BugFeatureRequestUc : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                NFEngine.InsertIssue(this.TextBox1.Text);
                this.lblMsg.Text = "Thanks!";
                this.lblMsg.CssClass = "success";
            }
            catch (Exception ex)
            {
                this.lblMsg.Text = "Error Occured! Please try again later.";
                this.lblMsg.CssClass = "error";
            }
        }
    }
}