using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient ;
using NF.Engine.Common;
using NF.Engine.Data;
using skmRss.Engine;

namespace NF.Engine.Source {
    public class SourceData : DataLogicBase {
        public DataTable GetNewsItems() {
            Database db = new Database();
            SqlCommand cmd = new SqlCommand();
            IDataReader rdr = db.ExecuteReader("Usp_Source_GetAll", cmd);
            List<KeyValuePair<int, string>> urls = new List<KeyValuePair<int, string>>();
            while (rdr.Read()) {
                urls.Add(new KeyValuePair<int, string>(Convert.ToInt32(rdr["SRC_LNK_ID"]), rdr["SRC_LNK_RSSURL"].ToString()));
            }
            rdr.Close();

            RssEngine eng = new RssEngine();
            RssDocument doc = null;

            DataTable dt = new DataTable();
            dt.Columns.Add("SRC_LNK_ID");
            dt.Columns.Add("ITM_TITLE");
            dt.Columns.Add("ITM_URL");
            dt.Columns.Add("ITM_CAT");
            dt.Columns.Add("ITM_DESC");
            dt.Columns.Add("ITM_PUBDATE");
            dt.Columns.Add("ITM_ADDEDDATE");
            dt.Columns.Add("ITM_DATEREF");
            dt.Columns.Add("ITM_IMGNAME");
            dt.Columns.Add("ITM_IMGTHUMB");
            dt.Columns.Add("ITM_IMAGE");
            dt.Columns.Add("ITM_FAILED");

            DataRow row = null;
            for (int i = 0; i < urls.Count; i++) {
                doc = eng.GetDataSource(urls[i].Value);

                for (int j = 0; j < doc.Items.Count; j++) {
                    row = dt.NewRow();
                    row["SRC_LNK_ID"] = urls[i].Key;
                    row["ITM_TITLE"] = doc.Items[j].Title;
                    row["ITM_URL"] = doc.Items[j].Link;
                    row["ITM_CAT"] = doc.Items[j].Category;
                    row["ITM_DESC"] = doc.Items[j].Description;
                    row["ITM_PUBDATE"] = doc.Items[j].PubDate;
                    row["ITM_ADDEDDATE"] = Util.GetDate();
                    row["ITM_DATEREF"] = Util.GetDate().ToMonthRef();
                    row["ITM_IMGNAME"] = string.Empty;
                    row["ITM_IMGTHUMB"] = string.Empty;
                    row["ITM_IMAGE"] = false;
                    row["ITM_FAILED"] = 0;

                    dt.Rows.Add(row);
                }
            }

            return dt;
            //SqlCommand cmd1 = new SqlCommand("INSERT_SOURCE_ITEMS", cnn);
            //SqlParameter para = new SqlParameter("@SOURCE_ITEMS", dt);
            //para.SqlDbType = SqlDbType.Structured;
            //para.TypeName = "dbo.SOURCE_ITEMS_TB";

            //cmd1.Parameters.Add(para);
            //cnn.Open();
            //cmd1.ExecuteNonQuery();
            //cnn.Close();
        }

   

        public IDataReader GetWebPages(string dateRef, string section, string source, string country) {
            Database db = new Database();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@DateRef", dateRef );
            cmd.Parameters.AddWithValue("@Source", source );
            cmd.Parameters.AddWithValue("@Section", section  );
            cmd.Parameters.AddWithValue("@Country", country );

            IDataReader rdr = db.ExecuteReader("Usp_Source_GetSourceItems", cmd);

            return rdr;
        }

        public IDataReader GetWebPages(string keyword) {
            Database db = new Database();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@SearchString", keyword);
            IDataReader rdr = db.ExecuteReader("Usp_Source_Search", cmd);
            return rdr;
        }


        public void InsertSourceItem(DataTable dt) {
            SqlCommand cmd = new SqlCommand();
            Database db = new Database();
            for (int i = 0; i < dt.Rows.Count; i++) {
                DataRow row = dt.Rows[i];
                cmd.Parameters.AddWithValue("@SRC_LNK_ID", row["SRC_LNK_ID"]);
                cmd.Parameters.AddWithValue("@ITM_TITLE", row["ITM_TITLE"]);
                cmd.Parameters.AddWithValue("@ITM_URL", row["ITM_URL"]);
                cmd.Parameters.AddWithValue("@ITM_CAT", row["ITM_CAT"]);
                cmd.Parameters.AddWithValue("@ITM_DESC", row["ITM_DESC"]);
                cmd.Parameters.AddWithValue("@ITM_PUBDATE", row["ITM_PUBDATE"]);
                cmd.Parameters.AddWithValue("@ITM_ADDEDDATE", row["ITM_ADDEDDATE"]);
                cmd.Parameters.AddWithValue("@ITM_DATEREF", row["ITM_DATEREF"]);
                cmd.Parameters.AddWithValue("@ITM_IMGNAME", row["ITM_IMGNAME"]);
                cmd.Parameters.AddWithValue("@ITM_IMGTHUMB", row["ITM_IMGTHUMB"]);
                cmd.Parameters.AddWithValue("@ITM_IMAGE", row["ITM_IMAGE"]);
                cmd.Parameters.AddWithValue("@ITM_FAILED", row["ITM_FAILED"]);

                db.ExecuteNonQuery("Usp_Source_InsertSourceItems", cmd);
                cmd.Parameters.Clear();
            }
        }

        public bool DoStarred(string userId, int itmId, bool isStar, DateTime dt) {
            try {
                Database db = new Database();
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@NF_USER_ID", userId );
                cmd.Parameters.AddWithValue("@ITM_ID", itmId);
                cmd.Parameters.AddWithValue("@STARRED", isStar );
                cmd.Parameters.AddWithValue("@ADDED_DATE", dt);
                db.ExecuteNonQuery("Usp_Source_Starred", cmd);
                return true;
            } catch (Exception ex ) {
                return false;
            }
        }

        public bool IsStarred(string userId, int itmId) {
            try {
                Database db = new Database();
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@USERID", userId);
                cmd.Parameters.AddWithValue("@ITM_ID", itmId);
                IDataReader rdr = db.ExecuteReader("Usp_Source_IsStarred", cmd);
                bool isStarred = rdr.Read();
                rdr.Close();
                return isStarred;
            } catch (Exception ex) {
                return false;
            }
        }
    }
}
