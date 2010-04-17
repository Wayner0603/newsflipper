using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using NF.Engine.Facade;
using System.Web.Security;

namespace newsflippers.services {
    [System.Web.Script.Services.ScriptService]
    public class UserService : System.Web.Services.WebService {

        [WebMethod]
        public bool Authenticate(string mode, string email, string password) {
            if (mode == "0") {
               //Login
                if (UserFacade.Login(email, password)) {
                    FormsAuthentication.SetAuthCookie(email, false);
                    return true;
                }
                return false;
            }
            else
            {
                //Create new user
                if (UserFacade.CreateUser(email, password, DateTime.Now, true) == NF.Engine.User.UserStatus.Duplicate)
                {
                    return false;
                }
                else {
                    FormsAuthentication.SetAuthCookie(email, false);
                    return true;
                }
                
            }
        }
    }
}
