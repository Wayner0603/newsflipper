using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NF.Engine.Common;
using Infonex.Security;

namespace NF.Engine.User {
    public class UserLogic : LogicBase<UserData> {

        public UserStatus  CreateUser(string email, string password, DateTime dt, bool active) {
            SaltedHash salt = SaltedHash.Create(password);
            string status = DataModel.CreateUser(email, salt.Salt, salt.Hash , dt, active);
            UserStatus ustatus = UserStatus.Success;

            if (status == "1001") {
                ustatus = UserStatus.Duplicate;
            }
            return ustatus;
        }

        public bool Login(string email, string password) {
            SaltedHash hash = DataModel.Login(email);
            if (hash == null) return false;

            return hash.Verify(password);
        }
    }

    public enum UserStatus { 
        Success,
        Duplicate,
        Invalid,
        Unknown
    }
}
