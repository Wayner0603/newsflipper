using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NF.Engine.Facade;
using System.Web.Security;

namespace newsflippers.user {
    public partial class login_uc : System.Web.UI.UserControl {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                Page.SetFocus(this.txtEmail);
            }
        }

        protected void Button1_Click(object sender, EventArgs e) {
            //try {
            //    if (!UserFacade.Login(this.txtEmail.Text, this.txtPass.Text)) {
            //        this.msg_ctrl1.SetMsg("Login failed!");
            //        return;
            //    }
            //    FormsAuthentication.SetAuthCookie(this.txtEmail.Text, this.chkSignIn.Checked);
            //    Response.Redirect("~/default.aspx");
            //} catch (Exception ex) {

            //}
        }
    }
}