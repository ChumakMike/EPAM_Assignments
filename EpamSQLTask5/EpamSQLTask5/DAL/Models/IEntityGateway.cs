using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamSQLTask5 {
    public interface IEntityGateway<T> where T : class {
        List<T> getAll();
        T getEntityById(int id);
        void addEntity(T entity);
        void updateEntity(T entity);
        void removeEntity(int id);
    }
}
