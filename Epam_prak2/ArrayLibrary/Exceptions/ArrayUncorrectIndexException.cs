using System;
using System.Collections.Generic;
using System.Text;

namespace ArrayLibrary {
    public class ArrayUncorrectIndexException : Exception {

        public ArrayUncorrectIndexException() : base() { }

        public ArrayUncorrectIndexException(string msg) : base(msg) { }
    }
}
