using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EpamSqlTask5EntityFramework {
    public class Product {
        private int id;
        private string name;
        private int provider_id;
        private int price;
        private int category_id;

        public Product() { }

        public Product(int id, string name, int provider_id, int price, int category_id) {
            this.id = id;
            this.name = name;
            this.provider_id = provider_id;
            this.price = price;
            this.category_id = category_id;
        }

        [Key]
        public int Id { get => id; set => id = value; }

        [Required]
        [MaxLength(100)]
        public string Name { get => name; set => name = value; }

        [Required]
        public int Price { get => price; set => price = value; }

        [ForeignKey("Provider")]
        public int Provider_id { get => provider_id; set => provider_id = value; }
        public virtual Provider Provider { get; set; }

        [ForeignKey("Category")]
        public int Category_id { get => category_id; set => category_id = value; }
        public virtual Category Category { get; set; }
        
        public int Order_id { get; set; }

    }
}
