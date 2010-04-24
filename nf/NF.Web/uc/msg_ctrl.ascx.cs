using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace newsflippers.uc
{
    public partial class msg_ctrl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void SetMsg(string text) {
            //this.lblMsg.Text = text;
        }
    }
}