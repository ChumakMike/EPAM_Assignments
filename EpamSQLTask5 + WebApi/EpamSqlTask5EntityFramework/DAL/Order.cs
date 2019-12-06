using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EpamSqlTask5EntityFramework {
    public class Order {
        private int id;
        private string name;
        public Order() { }

        public Order(string name) {
            this.name = name;
        }

        [Key]
        public int Id { get => id; set => id = value; }

        [Required]
        [MaxLength(100)]
        public string Name { get => name; set => name = value; }

    }
}
