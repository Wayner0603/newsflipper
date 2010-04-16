using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NF.Engine.Common;
using Infonex.Security;

namespace NF.Engine.User {
    public class UserLogic : LogicBase<UserData> {

        public void CreateUser(string email, string salt, string hash, DateTime dt, bool active) {
            DataModel.CreateUser(email, salt, hash, dt, active);
        }

        public bool Login(string email, string password) {
            SaltedHash hash = DataModel.Login(email);
            if (hash == null) return false;

            return hash.Verify(password);
        }
    }   
}
