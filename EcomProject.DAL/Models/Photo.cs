using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomProject.DAL.Models
{
    public class Photo
    {
        public Guid PhotoId { get; set; }
        public string PhotoName { get; set; } = string.Empty;

        public string PhotoPath { get; set; } = string.Empty;

        public Guid ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
