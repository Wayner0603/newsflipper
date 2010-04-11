using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using skmRss.Engine;
using System.Collections;
using System.Configuration;

namespace NF.Core
{
    public class NFEngine
    {
        public static string DATE_LONG_FORMAT = "dd MM yyyy hh:mm tt";
        public static string DATE_SHORT_FORMAT = "ddMMyyyy";
        private const string DATE = "<DATE>";
        
        //Processes main path
        private static string imagePath = @"D:\NF_PROCESS\IMAGES\";

        public static DateTime GetDate() {
            return DateTime.UtcNow;
        }

        public static DateTime LocalDate()
        {
            string timespanstr = "5:30"; //ConfigurationSettings.AppSettings["LocalTime"];
            char[] c = { ':' };
            string hr = timespanstr.Split(c)[0];
            string min = timespanstr.Split(c)[1];

            TimeSpan s = new TimeSpan(Convert.ToInt32(hr), Convert.ToInt32(min), 0);
            return DateTime.UtcNow.Add(s);
        }

        public static string GetCacheKey()
        {
            return string.Format("links_{0}", LocalDate().ToString(DATE_SHORT_FORMAT));
        }

        public static string GetPreviousCacheKey()
        {
            return string.Format("links_{0}", LocalDate().AddDays(-1).ToString(DATE_SHORT_FORMAT));
        }

        public static string GetImageFolder()
        {
            return string.Format(@"{3}{0}\{1}\{2}\", Extensions.ToYear(NFEngine.LocalDate()), Extensions.ToMonth(NFEngine.LocalDate()), Extensions.ToDay(NFEngine.LocalDate()), imagePath );
        }

        public static string ToImageString(string url)
        {
            url = FormatURL(url);
            return url.Replace("http://www.", "").Replace("/", "");
        }

        public static string FormatURL(string url)
        {
            string dateTimeText = Extensions.ToNewsDateTimeFull(LocalDate());
            if (url.Contains(DATE))
            {
                url = url.Replace(DATE, dateTimeText);
                return url;
            }
            return url;
        }

        public static DataTable GetNewsItems()
        {
            SqlConnection cnn = new SqlConnection(GetConnectionString());
            cnn.Open();
            SqlCommand cmd = new SqlCommand("GET_SOURCES", cnn);
            SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            List<KeyValuePair<int, string>> urls = new List<KeyValuePair<int, string>>();
            while (rdr.Read())
            {
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
            for (int i = 0; i < urls.Count; i++)
            {
                doc = eng.GetDataSource(urls[i].Value);

                for (int j = 0; j < doc.Items.Count; j++)
                {
                    row = dt.NewRow();
                    row["SRC_LNK_ID"] = urls[i].Key;
                    row["ITM_TITLE"] = doc.Items[j].Title;
                    row["ITM_URL"] = doc.Items[j].Link;
                    row["ITM_CAT"] = doc.Items[j].Category;
                    row["ITM_DESC"] = doc.Items[j].Description;
                    row["ITM_PUBDATE"] = doc.Items[j].PubDate;
                    row["ITM_ADDEDDATE"] = GetDate();
                    row["ITM_DATEREF"] = Extensions.ToMonthRef(GetDate());
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

        public static List<CaptureWebPage> GetCaptureWebPages()
        {
            return GetCaptureWebPages(Extensions.ToMonthRef(GetDate()));
        }

        public static List<CaptureWebPage> GetCaptureWebPages(string dt)
        {
            SqlConnection cnn = new SqlConnection(GetConnectionString());
            SqlCommand cmd = new SqlCommand("GET_SOURCE_ITEMS", cnn);
            cmd.Parameters.AddWithValue("@DATE_REF", dt);
            cnn.Open();
            SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            List<CaptureWebPage> childSources = new List<CaptureWebPage>();
            while (rdr.Read())
            {
                childSources.Add(new CaptureWebPage()
                {
                    Title = rdr["NMG_TITLE"].ToString(),
                    ImageName = rdr["NMG_IMAGENAME"].ToString(),
                    Url = rdr["NMG_URL"].ToString()
                });
            }
            rdr.Close();
            cnn.Close();
            return childSources;
        }

        public static void InsertSourceItem(DataTable dt) {
           
            SqlConnection cnn = new SqlConnection(GetConnectionString());
            SqlCommand cmd = new SqlCommand("INSERT_SOURCE_ITEMS_1", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cnn.Open();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row= dt.Rows[i];
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

                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            cnn.Close();
        }

        public static string GetConnectionString()
        {
            return @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=NF_2;Data Source=LUDMAL_PC";
        }

        public static void InsertIssue(string issueText)
        {
            SqlConnection cnn = new SqlConnection(GetConnectionString());
            SqlCommand cmd = new SqlCommand("USP_ISSUES_INSERT", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ISS_TEXT", issueText);
            cmd.Parameters.AddWithValue("@ISS_DATE", DateTime.UtcNow);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

       
    }
}