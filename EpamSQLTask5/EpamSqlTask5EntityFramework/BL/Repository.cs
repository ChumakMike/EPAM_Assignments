using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EpamSqlTask5EntityFramework.BL {
    public class Repository<T> : IRepository<T> where T : class {

        private Context c;
        public Repository(Context cont) {
            this.c = cont;
        }

        public void Delete(int id) {
            T delEntity = c.Set<T>().Find(id);
            if(c.Entry(delEntity).State == EntityState.Detached) {
                c.Set<T>().Attach(delEntity);
            }
            c.Set<T>().Remove(delEntity);
        }

        public IEnumerable<T> GetAll() {
            return c.Set<T>().ToList();
        }

        public T GetById(int id) {
            return c.Set<T>().Find(id);
        }

        public void Insert(T entity) {
            c.Set<T>().Add(entity);
        }

        public void Save() {
            c.SaveChanges();
        }

        public void Update(T entity) {
            c.Set<T>().Attach(entity);
            c.Entry(entity).State = EntityState.Modified; 
        }
    }
}
