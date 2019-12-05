using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixTask {
    class NotEqualSizeException : Exception {
        public NotEqualSizeException() : base("Not equal sizes of two matrixes") { }
    }
}
