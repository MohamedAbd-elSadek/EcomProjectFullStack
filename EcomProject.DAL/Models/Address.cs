//using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcomProject.DAL.Models
{
    public class Address 
    {
        public int AddressId { get; set; }
        public string City { get; set; } = string.Empty;

        public string ZipCode { get; set; } = string.Empty;

        public string Street { get; set; } = string.Empty;

        public string State { get; set; } = string.Empty;

        [ForeignKey("userId")]
        public Guid userId { get; set; }
        public virtual User User { get; set; }





    }
}