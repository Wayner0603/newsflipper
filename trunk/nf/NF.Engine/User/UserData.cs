using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NF.Engine.Common ;
using NF.Engine.Data;
using Infonex.Security;
using System.Data.SqlClient;
using System.Data;

namespace NF.Engine.User {
    public class UserData : DataLogicBase {
            
        public string CreateUser(string email, string salt, string hash, DateTime dt, bool active) {
            string satus = string.Empty;
            try
            {
                Database db = new Database();
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@USER_ID", email);
                cmd.Parameters.AddWithValue("@USER_SALT", salt);
                cmd.Parameters.AddWithValue("@USER_HASH", hash);
                cmd.Parameters.AddWithValue("@USER_CREATEDDATE", dt);
                cmd.Parameters.AddWithValue("@USER_ACTIVE", active);
                //SqlParameter para = new SqlParameter("@MSG", SqlDbType.Char);
                //para.Direction = ParameterDirection.Output;
                //cmd.Parameters.Add(para);
                db.ExecuteNonQuery("Gsp_Users_Insert", cmd);
                return "1000";// cmd.Parameters["@MSG"].Value.ToString();
            }
            catch (Exception ex)
            {
                return "1001";
            }
           
        }

        public SaltedHash Login(string email) {
            Database db = new Database();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@USER_ID", email);

            IDataReader rdr = db.ExecuteReader("Usp_Users_Login", cmd);
            SaltedHash saltO = null;
            while (rdr.Read()) {
                saltO = SaltedHash.Create(rdr["USER_SALT"].ToString(), rdr["USER_HASH"].ToString());   
            }
            
            rdr.Close();
            return saltO;
        }
    }
}
