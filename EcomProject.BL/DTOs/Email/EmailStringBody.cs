using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomProject.BL.DTOs.Email
{
    public class EmailStringBody
    {
        public static string send (string email,string token,string componenet,string body)
        {
            string encodeToke = Uri.EscapeDataString(token);
            return $@"
                        <html> 
                                <head></head>
                                <body>
                                        <h1>{body} </h1>
                                                </body>
                                        <br>
                
                                <a href=""http://localhost:4200/Account/{componenet}?email={email}&code={encodeToke}""> {body}</a>
                                            </html>
        
                                    ";
        }
    }
}
