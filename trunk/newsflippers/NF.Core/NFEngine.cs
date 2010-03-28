using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using skmRss.Engine;
using Infonex.Data;

namespace NF.Core
{
    public class NFEngine
    {
        public static void ProcessRss()
        {
            try
            {
                RssEngine engine = new RssEngine();
                List<NewsSource> sources = NewsSource.GetSources();
                if (sources.Count > 0)
                {
                    foreach (NewsSource item in sources)
                    {
                        RssDocument doc = engine.GetDataSource(item.RssUrl);
                        if (doc.Items.Count > 0)
                        {
                            foreach (RssItem rssItem in doc.Items)
                            {
                                NewsLink.Create(item.Id, rssItem.Title, rssItem.Description, rssItem.Link, rssItem.Author, rssItem.Category, rssItem.PubDate, DateTime.UtcNow, DateTime.UtcNow.ToString("yyyyMMddhh"),string.Empty);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }

        }
    }
}
