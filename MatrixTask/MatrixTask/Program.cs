using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixTask {
    class Program {
        static void Main(string[] args) {
            Matrix m = new Matrix(2, 2);
            m.fillRandom();
            m.printMatrix();

            m.serialize();

            Console.WriteLine("Matrix mult on num");
            Matrix m2 = m * 5;
            m2.printMatrix();

            Console.WriteLine("Matrix add");
            Matrix m3 = m + m2;
            m3.printMatrix();

            Console.WriteLine("Matrix subtract");
            Matrix m4 = m - m2;
            m4.printMatrix();

            Console.WriteLine("Matrix mult");
            Matrix m5 = m * m2;
            m5.printMatrix();

            Console.ReadKey();
        }
    }
}
