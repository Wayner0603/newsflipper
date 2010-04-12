using System;
using System.Collections.Generic;
using System.Text;

namespace NF.Engine
{
    public class RssPost
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Catagory { get; set; }
        public string Guid { get; set; }
        public string Url { get; set; }
        public DateTime PubDate { get; set; }
        public DateTime AddedDate { get; set; }
        public string Status { get; set; }

    }

    public class RssPostCollection : List<RssPost>
    {

    }
}
