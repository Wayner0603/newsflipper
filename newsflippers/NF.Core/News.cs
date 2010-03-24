using System;
using System.Collections.Generic;
using System.Text;
using Infonex.Data;
using System.Data.SqlClient;
using System.Data;

namespace NF.Core
{
    public class News 
    {
        public static void Insert(int source, string title, string desc, string link, string author, string category, DateTime pubdate, DateTime extractedDate, string dateref, string imageName) {
            Database db = new Database();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@NEWS_SOURCE", source );
            cmd.Parameters.AddWithValue("@NEWS_TITLE", title );
            cmd.Parameters.AddWithValue("@NEWS_DESC", desc );
            cmd.Parameters.AddWithValue("@NEWS_LINK", link );
            cmd.Parameters.AddWithValue("@NEWS_AUTHOR", author );
            cmd.Parameters.AddWithValue("@NEWS_CATEGORY",category );
            cmd.Parameters.AddWithValue("@NEWS_PUBDATE", pubdate );
            cmd.Parameters.AddWithValue("@NEWS_EXTRACT_DATE",extractedDate );
            cmd.Parameters.AddWithValue("@NEWS_DATEREF",dateref );
            cmd.Parameters.AddWithValue("@NEWS_IMAGE_NAME",imageName );
            cmd.Parameters.AddWithValue("@NEWS_IMAGE_GENERATED", false );
            db.ExecuteNonQuery("NEWSL_LINKS__INSERT", cmd);
        }

        public static DataSet GetData() {
            Database db = new Database();
            SqlCommand cmd = new SqlCommand();
            return db.ExecuteDataSet("NEWS_LINKS__GETDATA", cmd);
        }
    }
}
