using System;
using System.Collections.Specialized ;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NF.Engine {
    public class WebPageTypeList : List<KeyValuePair<string,string>> {
        public void Add(string key, string value) {
            this.Add(new KeyValuePair<string, string>(key, value));
        }
    }
}
