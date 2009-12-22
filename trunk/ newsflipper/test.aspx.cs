using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace newsflippers
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Label1.Text = string.Format("Sri Lanka:{0} Utc:{1}", Extensions.ToLocalDateTime(DateTime.UtcNow).ToString("dd MM yyyy, hh:mm tt"), DateTime.UtcNow.ToString("dd MM yyyy, hh:mm tt"));
        }
    }
}
