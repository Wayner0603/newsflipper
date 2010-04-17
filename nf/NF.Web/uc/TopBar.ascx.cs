using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace newsflippers.uc
{
    public partial class TopBar : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                if (Request.IsAuthenticated)
                {
                    this.hpLogin.Visible = false;
                    this.hpSingOut.Visible = true;
                    this.lblUser.Text = Context.User.Identity.Name;
                }
            }
        }
    }
}