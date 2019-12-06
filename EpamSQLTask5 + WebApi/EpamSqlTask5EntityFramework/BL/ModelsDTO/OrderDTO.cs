using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamSqlTask5EntityFramework {
    public class OrderDTO {

        public int Id { get; set; }
        public string Name { get; set; }

        public List<ProductDTO> Products { get; set; }
    }
}
