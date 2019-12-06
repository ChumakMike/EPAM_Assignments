using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixTask {
    class NotRightSizeOfMatrixException : Exception {
        public NotRightSizeOfMatrixException() : base("Not right sizes of matrix") { }
    }
}
