using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamSQLTask5 {
    class Program {
        static void Main(string[] args) {
            Service s = new Service();
            s.getAllProductsWithCategories();
            space();
            s.getAllProvidersWithProducts();
            space();
            s.getAllProvidersWithCategories();
            space();
            s.getAllProvidersWithCategoriesOrdered();
            Console.ReadKey();
        }
        public static void space() {
            for (int i = 0; i < 3; i++)
                Console.WriteLine();
        }
    }
}
