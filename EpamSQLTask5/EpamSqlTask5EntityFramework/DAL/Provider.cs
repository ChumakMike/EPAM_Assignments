using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EpamSqlTask5EntityFramework {
    public class Provider {
        private int id;
        private string name;
        private string adress;

        public Provider(int id, string name, string adress) {
            this.id = id;
            this.name = name;
            this.adress = adress;
        }

        [Key]
        public int Id { get => id; set => id = value; }

        [Required]
        [MaxLength(100)]
        public string Name { get => name; set => name = value; }

        [Required]
        [MaxLength(100)]
        public string Adress { get => adress; set => adress = value; }

        public List<Product> Products { get; set; }
    }
}
