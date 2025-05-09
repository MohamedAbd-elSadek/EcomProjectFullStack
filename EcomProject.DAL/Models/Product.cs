using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomProject.DAL.Models
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty ;

        public DateOnly ManufactureDate { get; set; }

        public decimal Price { get; set; }

        public int Discount { get; set; }
        [ForeignKey("Category")]
        public Guid CategoryId { get; set; }

        public virtual Category Category { get; set; }


        public virtual ICollection<Photo> Photos { get; set; } = new HashSet<Photo>();  


    }
}
