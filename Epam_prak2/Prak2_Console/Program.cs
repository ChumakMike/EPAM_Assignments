using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArrayLibrary;
using BSTree;

namespace Prak2_Console {

    class Program {
        static void Main(string[] args) {
            /*Array<int> arr = new Array<int>(-1, 4, 2, 6, 7, 8, 10, 11, 12, 11, 12, 11, 12);
            arr.Print();
            Console.WriteLine("arrlen = " + arr.ArrLen);
            Console.WriteLine("First index -> " + arr.First.ToString());
            Console.WriteLine("Num on -1 index -> " + arr[-1].ToString());
            */
            Student A = new Student("", "Chumak", "", 40);
            Student B = new Student("", "Adamenko", "", 50);
            Student C = new Student("", "Adamenko", "", 30);
            Student D = new Student("", "Adamenko", "", 20);
            Student E = new Student("", "Adamenko", "", 35);
            BSTree<Student> bSTree = new BSTree<Student>(A);

            bSTree.Insert(B);
            bSTree.Insert(C);
            bSTree.Insert(D);
            bSTree.Insert(E);
            foreach (var i in bSTree.preOrderTraversal(bSTree.Root))
                Console.Write(i.Data.TestResult + " ");
            
            Console.ReadKey();
        }
    }
}
