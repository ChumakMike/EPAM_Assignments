using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamSqlTask5EntityFramework {
    public class Service {

        public void getAllProductsWithCategories() {
            using(Context db = new Context()) {
                var categories = db.Categories;
                var products = db.Products;
                var res = categories.GroupJoin(products,
                    c => c.Id,
                    p => p.Category_id,
                    (c, p) => new {
                        catName = c.CategoryName,
                        products = p.Select(x => x.Name)
                    }).OrderByDescending(x => x.products.Count());
                foreach(var r in res) {
                    Console.WriteLine();
                    Console.WriteLine($"Category -> {r.catName}");
                    foreach(var p in r.products)
                        Console.WriteLine($"Product -> {p}");
                }
            }
        }

        public void getAllProvidersWithCategories() {
            using(Context db = new Context()) {
                var categories = db.Categories;
                var products = db.Products;
                var providers = db.Providers;
                var res = providers.GroupJoin(products,
                    pr => pr.Id,
                    p => p.Provider_id,
                    (pr, p) => new {
                        provName = pr.Name,
                        provAdress = pr.Adress,
                        Products = p.GroupBy(x=>x.Category_id).GroupJoin(categories,
                            prod => prod.Key,
                            cat => cat.Id,
                            (prod, cat) => new {
                                categs = cat.GroupBy(x => x.CategoryName).Select(x => x.Key)
                            })
                    });

                foreach(var r in res) {
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine($"Provider : {r.provName}, Adress : {r.provAdress}");
                    foreach (var pr in r.Products) {
                        foreach (var c in pr.categs)
                            Console.WriteLine($"Category -> {c}");
                    }
                }
            }
        }

        public void getAllProvidersWithProducts() {
            using(Context db = new Context()) {
                var products = db.Products;
                var providers = db.Providers;
                var res = providers.GroupJoin(products,
                    pr => pr.Id,
                    p => p.Provider_id,
                    (pr, p) => new {
                        ProvName = pr.Name,
                        ProvAdr = pr.Adress,
                        Products = p.Select(x => x.Name)
                    });

                foreach(var r in res) {
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine($"Provider : {r.ProvName}, Adress : {r.ProvAdr}");
                    foreach(var productFromRequest in r.Products)
                        Console.WriteLine($"Product -> {productFromRequest}");
                }
            }
        }

        public void getProductsOrderedDescendingByPrice() {
            using(Context db = new Context()) {
                var products = db.Products;
                var res = products.OrderByDescending(x => x.Price).Select(pr => new {
                    prodName = pr.Name,
                    prodPrice = pr.Price
                });
                foreach(var r in res) {
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine($"Product -> {r.prodName}");
                    Console.WriteLine($"Price -> {r.prodPrice}");
                }
            }
        }
    }
}
