using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamSqlTask5EntityFramework {
    class Program {
        static void Main(string[] args) {
            Service service = new Service();
            service.getAllProductsWithCategories();
            space();
            service.getAllProvidersWithCategories();
            space();
            service.getAllProvidersWithProducts();
            space();
            service.getProductsOrderedDescendingByPrice();
            space();
            Console.ReadKey();
        }
        public static void space() {
            for (int i = 0; i < 3; i++)
                Console.WriteLine();
        }
    }
}
