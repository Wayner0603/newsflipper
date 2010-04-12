using System;
using System.Collections.Generic;
using System.Text;
using Infonex.Data;
using System.Data;
using System.Data.SqlClient ;

namespace NF.Core
{
    public class NewsSource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string RssUrl { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastAccessedDateTime { get; set; }

        private static NewsSourceCollection GetNewsSourceList(IDataReader rdr)
        {
            NewsSourceCollection srcCol = new NewsSourceCollection();

            while (rdr.Read())
            {
                srcCol.Add(new NewsSource()
                {
                    Id = (int)rdr["SRC_ID"],
                    Name = rdr["SRC_NAME"].ToString(),
                    Url = rdr["SRC_URL"].ToString(),
                    RssUrl = rdr["SRC_RSS_URL"].ToString(),
                    Active = (bool)rdr["SRC_ACTIVE"]

                });
            }
            rdr.Close();
            return srcCol;
        }

        public static NewsSourceCollection GetSources()
        {
            Database db = new Database();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            IDataReader rdr = db.ExecuteReader("USP_NEWS_SOURCES_GETALL", cmd);
            return GetNewsSourceList(rdr);
        }

    }

    public class NewsSourceCollection : List<NewsSource>
    {

    }
}
