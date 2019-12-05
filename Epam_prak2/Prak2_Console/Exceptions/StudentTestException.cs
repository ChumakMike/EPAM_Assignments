using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prak2_Console {
    public class StudentTestException : Exception {
        public StudentTestException() : base() { }

        public StudentTestException(string msg) : base(msg) { }
    }
}
