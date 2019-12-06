namespace EpamSqlTask5EntityFramework {
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class Context : DbContext {

        public Context()
            : base("name=Context.xml") {
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Provider> Providers { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
    }
}