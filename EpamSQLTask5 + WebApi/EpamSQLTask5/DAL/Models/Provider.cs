using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamSQLTask5 {
    public class Provider : IEntityGateway<Provider> {
        private int id;
        private string name;
        private string adress;
        private ProviderGateway providerGateway = new ProviderGateway();

        public Provider() { }

        public Provider(int id, string name, string adress) {
            this.id = id;
            this.name = name;
            this.adress = adress;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Adress { get => adress; set => adress = value; }

        public void addEntity(Provider entity) {
            providerGateway.addEntity(entity);
        }

        public List<Provider> getAll() {
            return providerGateway.getAll();
        }

        public Provider getEntityById(int id) {
            return providerGateway.getEntityById(id);
        }

        public void removeEntity(int id) {
            providerGateway.removeEntity(id);
        }

        public void updateEntity(Provider entity) {
            providerGateway.updateEntity(entity);
        }
    }
}
