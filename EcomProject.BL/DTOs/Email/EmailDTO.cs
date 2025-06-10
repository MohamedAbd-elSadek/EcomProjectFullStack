using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomProject.BL.DTOs.Email
{
    public class EmailDTO
    {
        public EmailDTO(string to, string from, string subject, string contect)
        {
            To = to;
            From = from;
            Subject = subject;
            Contect = contect;
        }

        public string To { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }
        public string Contect { get; set; }
    }
}
