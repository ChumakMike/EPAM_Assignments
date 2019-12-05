using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamSQLTask5 {
    public class Product : IEntityGateway<Product> {
        private int id;
        private string name;
        private int provider_id;
        private ProductGateway productGateway = new ProductGateway();

        public Product() { }

        public Product(int id, string name, int provider_id) {
            this.id = id;
            this.name = name;
            this.provider_id = provider_id;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int Provider_id { get => provider_id; set => provider_id = value; }

        public void addEntity(Product entity) {
            productGateway.addEntity(entity);
        }

        public List<Product> getAll() {
            return productGateway.getAll();
        }

        public Product getEntityById(int id) {
            return productGateway.getEntityById(id);
        }

        public void removeEntity(int id) {
            productGateway.removeEntity(id);
        }

        public void updateEntity(Product entity) {
            productGateway.updateEntity(entity);
        }
    }
}
