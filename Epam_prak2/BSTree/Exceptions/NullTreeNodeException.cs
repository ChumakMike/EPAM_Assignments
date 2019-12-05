using System;
using System.Collections.Generic;
using System.Text;

namespace BSTree {
    public class NullTreeNodeException : Exception {

        public NullTreeNodeException() : base() { }

        public NullTreeNodeException(string mes) : base(mes) { }
    }
}
