using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomProject.BL.DTOs.Auth
{
    public record ResetPassword (string email, string password,string token);
    
}
