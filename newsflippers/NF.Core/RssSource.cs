using System;
using System.Collections.Generic;
using System.Text;

namespace NF.Core
{
    public class RssSource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string RssUrl { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastAccessedDateTime { get; set; }

    }

    public class RssSourceCollection : List<RssSource>
    {

    }
}
