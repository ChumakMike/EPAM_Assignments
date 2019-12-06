using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolinomTask {
    class Program {
        static void Main(string[] args) {
            Polinom p = new Polinom(1, 2);
            p.printPolinom();


            Polinom p2 = new Polinom(2, 2);
            p2.printPolinom();

           /* Polinom p3 = p + p2;
            p3.printPolinom();

            Polinom p4 = p - p2;
            p4.printPolinom();*/

            Polinom p5 = p * p2;
            p5.printPolinom();
            Console.ReadKey();
        }
    }
}
