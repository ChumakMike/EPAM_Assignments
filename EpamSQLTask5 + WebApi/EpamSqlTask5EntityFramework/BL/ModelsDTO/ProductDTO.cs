using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamSqlTask5EntityFramework {
    public class ProductDTO {

        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Provider_id { get; set; }
        public int Category_id { get; set; }
        public int Order_id { get; set; }
    }
}
