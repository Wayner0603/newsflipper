using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NF.Engine.User;

namespace NF.Engine.Facade {
    public class UserFacade {
        public static void CreateUser(string email, string salt, string hash, DateTime dt, bool active) {
            UserLogic logic = new UserLogic();
            logic.CreateUser(email, salt, hash, dt, active);
        }

        public static bool Login(string email, string password) {
            UserLogic logic = new UserLogic();
            return logic.Login(email, password );
        }

    }
}
