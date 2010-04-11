using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using skmRss.Engine;
using Infonex.Data;

namespace NF.Core
{
    public class RssManager
    {
        /// <summary>
        /// Creates the new source.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="url">The URL.</param>
        /// <param name="rssUrl">The RSS URL.</param>
        /// <param name="active">if set to <c>true</c> [active].</param>
        public void CreateNewSource(string name, string url, string rssUrl, bool active)
        {
            try
            {
                Database db = new Database();
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@SRC_NAME", name);
                cmd.Parameters.AddWithValue("@SRC_URL", url);
                cmd.Parameters.AddWithValue("@SRC_RSSURL", rssUrl);
                cmd.Parameters.AddWithValue("@SRC_ACTIVE", active);
                db.ExecuteNonQuery("USP_SOURCES_INSERT", cmd);
            }
            catch (Exception ex)
            {
            }
        }

      
        public bool ProcessRss()
        {
            try
            {
                RssEngine engine = new RssEngine();
                List<RssSource> sources = GetSources();
                if (sources.Count > 0)
                {
                    foreach (RssSource item in sources)
                    {
                        RssDocument doc = engine.GetDataSource(item.RssUrl);
                        if (doc.Items.Count > 0)
                        {
                            foreach (RssItem rssItem in doc.Items)
                            {
                                CreateNewPost(rssItem.Title, rssItem.Description, rssItem.Author, rssItem.Category, DateTime.UtcNow, rssItem.Link, rssItem.PubDate, string.Empty, item.Id);
                            }
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {

            }
            return false;

        }

        public RssItemList GetRssItems(string url)
        {
            if (string.IsNullOrEmpty(url)) throw new Exception("Invalid URL");
            RssEngine eng = new RssEngine();
            RssDocument doc = eng.GetDataSource(url);
            return doc.Items;
        }

        /// <summary>
        /// Creates the new post.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="desc">The desc.</param>
        /// <param name="author">The author.</param>
        /// <param name="catagory">The catagory.</param>
        /// <param name="guid">The GUID.</param>
        /// <param name="link">The link.</param>
        /// <param name="pubDate">The pub date.</param>
        /// <param name="status">The status.</param>
        public void CreateNewPost(string title, string desc, string author, string catagory, DateTime addedDate, string link, DateTime pubDate, string status, int sourceId)
        {
            try
            {
                Database db = new Database();
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@RSS_TITLE", title);
                cmd.Parameters.AddWithValue("@RSS_DESC", desc);
                cmd.Parameters.AddWithValue("@RSS_AUTHOR", author);
                cmd.Parameters.AddWithValue("@RSS_CATAGORY", catagory);
                cmd.Parameters.AddWithValue("@RSS_ADDEDDATE", addedDate);
                cmd.Parameters.AddWithValue("@RSS_LINK", link);
                cmd.Parameters.AddWithValue("@RSS_PUBDATE", pubDate);
                cmd.Parameters.AddWithValue("@RSS_SOURCEID", sourceId);
                db.ExecuteNonQuery("USP_RSS_POSTS_INSERT", cmd);
            }
            catch (Exception ex)
            {
            }
        }

       

        private RssSourceCollection GetSourceList(IDataReader rdr)
        {
            RssSourceCollection srcCol = new RssSourceCollection();

            while (rdr.Read())
            {
                srcCol.Add(new RssSource()
                {
                    Id = (int)rdr["SRC_ID"],
                    Name = rdr["SRC_NAME"].ToString(),
                    Url = rdr["SRC_URL"].ToString(),
                    RssUrl = rdr["SRC_RSS"].ToString(),
                    Active = (bool)rdr["SRC_ACTIVE"]

                });
            }
            rdr.Close();
            return srcCol;
        }

        public RssSourceCollection GetSources()
        {
            Database db = new Database();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            IDataReader rdr = db.ExecuteReader("USP_SOURCES_GETALL", cmd);
            return GetSourceList(rdr);
        }
    }
        
}
