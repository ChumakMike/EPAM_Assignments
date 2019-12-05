using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamSQLTask5 {
    public class Category : IEntityGateway<Category> {
        private int id;
        private string categoryName;
        private int product_id;
        private CategoryGateway categoryGateway = new CategoryGateway();

        public Category() { }

        public Category(int id, string category, int product_id) {
            this.id = id;
            this.categoryName = category;
            this.product_id = product_id;
        }

        public int Id { get => id; set => id = value; }
        public string CategoryName { get => categoryName; set => categoryName = value; }
        public int Product_id { get => product_id; set => product_id = value; }

        public void addEntity(Category entity) {
            categoryGateway.addEntity(entity);
        }

        public List<Category> getAll() {
            return categoryGateway.getAll();
        }

        public Category getEntityById(int id) {
            return categoryGateway.getEntityById(id);
        }

        public void removeEntity(int id) {
            categoryGateway.removeEntity(id);
        }

        public void updateEntity(Category entity) {
            categoryGateway.updateEntity(entity);
        }
    }
}
