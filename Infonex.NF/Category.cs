using System;
using System.Collections.Generic;
using System.Text;

namespace Infonex.NF.Core {
    public class Category {
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
       
        private bool _Active = true;
        public bool Active {
            get { return _Active; }
            set { _Active = value; }
        }
    }
}
