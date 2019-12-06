using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamSqlTask5EntityFramework {
    public class UnitOfWork : IDisposable {

        private Context c = new Context();
        private Repository<Category> categoryRep;
        private Repository<Product> productRep;
        private Repository<Provider> providerRep;
        private Repository<Order> orderRep;

        private bool disposed = false;

        public Repository<Order> OrderRep {
            get {
                if (orderRep == null)
                    this.orderRep = new Repository<Order>(c);
                return orderRep;
            }
        }

        public Repository<Category> CategoryRep {
            get {
                if (categoryRep == null)
                    this.categoryRep = new Repository<Category>(c);
                return categoryRep;
            } 
        }
        public Repository<Product> ProductRep {
            get {
                if (productRep == null)
                    this.productRep = new Repository<Product>(c);
                return productRep;
            }
        }

        public Repository<Provider> ProviderRep {
            get {
                if (providerRep == null)
                    this.providerRep = new Repository<Provider>(c);
                return providerRep;
            }
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disp) {
            if(!this.disposed) {
                if (disp)
                    c.Dispose();
                this.disposed = true;
            }
        }

        public void Save() {
            c.SaveChanges();
        }
    }
}
