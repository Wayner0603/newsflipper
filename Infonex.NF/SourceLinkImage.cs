using System;
using System.Collections.Generic;
using System.Text;

namespace Infonex.NF.Core {
    public class SourceLinkImage {
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

        private int _SourceLinkID;
        public int SourceLinkID {
            get { return _SourceLinkID; }
            set { _SourceLinkID = value; }
        }
        private string _ImageName;
        public string ImageName {
            get { return _ImageName; }
            set { _ImageName = value; }
        }

        private string _DateRef;
        public string DateRef {
            get { return _DateRef; }
            set { _DateRef = value; }
        }

        private string _Title;
        public string Title {
            get { return _Title; }
            set { _Title  = value; }
        }

        private string _Url;
        public string Url {
            get { return _Url; }
            set { _Url = value; }
        }

        private DateTime _GeneratedDate;
        public DateTime GeneratedDate {
            get { return _GeneratedDate; }
            set { _GeneratedDate = value; }
        }
    }
}
