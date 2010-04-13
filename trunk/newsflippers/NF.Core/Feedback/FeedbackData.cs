using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NF.Engine.Common;
using NF.Engine.Data;
using System.Data;
using System.Data.SqlClient;

namespace NF.Engine.Feedback {
    public class FeedbackData : DataLogicBase {
        public void InsertIssue(string issueText) {
            Database db = new Database();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@ISS_TEXT", issueText);
            cmd.Parameters.AddWithValue("@ISS_DATE", DateTime.UtcNow);
            db.ExecuteNonQuery("Usp_Issues_Insert", cmd);
        }
    }
}
