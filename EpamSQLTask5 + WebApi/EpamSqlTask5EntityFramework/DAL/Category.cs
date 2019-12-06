using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EpamSqlTask5EntityFramework {
    public class Category {
        private int id;
        private string categoryName;
        public Category() { }
        public Category(int id, string categoryName) {
            this.id = id;
            this.categoryName = categoryName;
        }

        [Key]
        public int Id { get => id; set => id = value; }

        [Required]
        [MaxLength(100)]
        public string CategoryName { get => categoryName; set => categoryName = value; }

        public List<Product> Products { get; set; }
    }
}
