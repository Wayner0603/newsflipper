using System;
using System.Collections.Generic;

using System.Web;

namespace newsflippers {
    public class Source {
        public int ID { get; set; }
        public string Title { get; set; }
        public bool Active { get; set; }
        public string Url { get; set; }
        public string Desc { get; set; }

    }
}
