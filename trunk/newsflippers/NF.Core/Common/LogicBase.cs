using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NF.Engine.Common {
    public class LogicBase<T> : ILogicBase
               where T : DataLogicBase, new() {
        private T _Model = default(T);
        public T DataModel {
            get {
                if (_Model == null) {
                    _Model = new T();
                }
                return _Model;
            }
            set { _Model = value; }
        }
    }
}
