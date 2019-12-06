using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamSQLTask5 {
    public class Service {
        #region 
        Category c = new Category();
        Product p = new Product();
        Provider pr = new Provider();
        #endregion

        public void getAllProductsWithCategories() {
            List<Category> categList = c.getAll();
            List<Product> prodList = p.getAll();
            var res = categList.Join(prodList,
                category => category.Product_id,
                product => product.Id,
                (category, product) => new {
                    catName = category.CategoryName,
                    productName = product.Name
                });
            foreach(var r in res) {
                Console.WriteLine();
                Console.WriteLine($"Category -> {r.catName}");
                Console.WriteLine($"Product -> {r.productName}");
            }
        }

        public void getAllProvidersWithProducts() {
            List<Provider> providersList = pr.getAll();
            List<Product> productsList = p.getAll();
            var res = providersList.GroupJoin(productsList,
                provider => provider.Id,
                product => product.Provider_id,
                (provider, product) => new {
                    ProvName = provider.Name,
                    ProvAdr = provider.Adress,
                    Products = product.Select(x => x.Name)
                });

            foreach (var r in res) {
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine($"Provider : {r.ProvName}, Adress : {r.ProvAdr}");
                foreach (var productFromRequest in r.Products) {    
                    Console.WriteLine($"Product -> {productFromRequest}");
                }
            }
        }

        public void getAllProvidersWithCategories() {
            List<Category> clist = c.getAll();
            List<Provider> providersList = pr.getAll();
            List<Product> productsList = p.getAll();

            var res = providersList.GroupJoin(productsList,
              provider => provider.Id,
              product => product.Provider_id,
              (provider, product) => new {
                  ProvName = provider.Name,
                  ProvAdr = provider.Adress,
                  Products = product.Join(clist,
                      p => p.Id,
                      c => c.Product_id,
                      (p, c) => new { prodName = p.Name, catName = c.CategoryName })
              });

            foreach (var r in res) {
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine($"Provider : {r.ProvName}, Adress : {r.ProvAdr}");
                foreach (var productFromRequest in r.Products) {
                    Console.WriteLine("#");
                    Console.WriteLine($"Product -> {productFromRequest.prodName}");
                    Console.WriteLine($"Category -> {productFromRequest.catName}");
                }
            }
        }

        public void getAllProvidersWithCategoriesOrdered() {
            List<Category> clist = c.getAll();
            List<Provider> providersList = pr.getAll();
            List<Product> productsList = p.getAll();

            var res = providersList.GroupJoin(productsList,
              provider => provider.Id,
              product => product.Provider_id,
              (provider, product) => new {
                  ProvName = provider.Name,
                  ProvAdr = provider.Adress,
                  Products = product.Join(clist,
                      p => p.Id,
                      c => c.Product_id,
                      (p, c) => new { prodName = p.Name, catName = c.CategoryName })
              }).OrderByDescending(x => x.Products.Count());

            foreach (var r in res) {
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine($"Provider : {r.ProvName}, Adress : {r.ProvAdr}");
                Console.WriteLine($"Categories count = {r.Products.Count()}");
                foreach (var productFromRequest in r.Products) {
                    Console.WriteLine("#");
                    Console.WriteLine($"Product -> {productFromRequest.prodName}");
                    Console.WriteLine($"Category -> {productFromRequest.catName}");
                }
            }

        }

    }
}
