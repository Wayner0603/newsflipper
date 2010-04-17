using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NF.Engine.User;

namespace NF.Engine.Facade {
    public class UserFacade {
        public static UserStatus CreateUser(string email, string password, DateTime dt, bool active) {
            UserLogic logic = new UserLogic();
            return logic.CreateUser(email, password, dt, active);
        }

        public static bool Login(string email, string password) {
            UserLogic logic = new UserLogic();
            return logic.Login(email, password );
        }

    }
}
