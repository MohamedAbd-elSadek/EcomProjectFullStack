using EcomProject.BL.DTOs.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomProject.BL.Manager.EmailSender
{
    public interface IEmailSender
    {
        Task SendEmail(EmailDTO emailDTO);
    }
}
