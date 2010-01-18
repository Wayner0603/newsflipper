using System;
using System.Collections.Generic;
using System.Text;

namespace Infonex.NF.Core {
    public class Source {
        private int _ID;
        public int ID {
            get { return _ID; }
            set { _ID = value; }
        }
        private string _Name = string.Empty;
        public string Name {
            get { return _Name; }
            set { _Name = value; }
        }
        private string _Url;
        public string Url {
            get { return _Url;}
            set { _Url = value; }
        }
        private bool _Active = true;
        public bool Active {
            get { return _Active; }
            set { _Active = value; }
        }

        private string _Country = string.Empty;
        public string Country {
            get { return _Country; }
            set { _Country = value; }
        }

        private double _SortOrder = 0.0;
        public double SortOrder {
            get { return _SortOrder; }
            set { _SortOrder = value; }
        }
    }
}
