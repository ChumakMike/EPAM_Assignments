using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamSqlTask5EntityFramework.BL {
    public interface IRepository<T> where T : class {
        T GetById(int id);
        IEnumerable<T> GetAll();
        void Update(T entity);
        void Delete(int id);
        void Insert(T entity);
        void Save();
    }
}
