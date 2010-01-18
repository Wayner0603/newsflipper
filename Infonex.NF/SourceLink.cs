using System;
using System.Collections.Generic;
using System.Text;

namespace Infonex.NF.Core {
    public class SourceLink {
        private int _ID;
        public int ID {
            get { return _ID; }
            set { _ID = value; }
        }
        private int _SourceID;
        public int SourceID {
            get { return _SourceID; }
            set { _SourceID = value; }
        }

        private int _CateogryID;
        public int CateogryID {
            get { return _CateogryID; }
            set { _CateogryID = value; }
        }

        private string _Url;
        public string Url {
            get { return _Url; }
            set { _Url = value; }
        }

        private string _Title;
        public string Title {
            get { return _Title; }
            set { _Title = value; }
        }

        private DateTime _AddedDate;
        public DateTime AddedDate {
            get { return _AddedDate; }
            set { _AddedDate = value; }
        }

        private string _Country = string.Empty;
        public string Country {
            get { return _Country; }
            set { _Country = value; }
        }

        private bool _Active = true;
        public bool Active {
            get { return _Active; }
            set { _Active = value; }
        }

    }
}
