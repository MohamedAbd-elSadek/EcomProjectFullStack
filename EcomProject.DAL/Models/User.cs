using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomProject.DAL.Models
{
    public class User : IdentityUser<Guid>
    {
        //public string UserName { get; set; } = string.Empty;
        public Address Address { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;



    }
}
