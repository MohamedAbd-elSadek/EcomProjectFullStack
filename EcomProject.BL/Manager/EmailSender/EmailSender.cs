using EcomProject.BL.DTOs.Email;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomProject.BL.Manager.EmailSender
{
    public class EmailSender : IEmailSender
    {
       private readonly IConfiguration configuration;

        public EmailSender(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task SendEmail(EmailDTO emailDTO)
        {
            var smtpHost = configuration["EmailSetting:Smtp"];
            var portString = configuration["EmailSetting:Port"];
            var fromAddress = configuration["EmailSetting:From"];
            var username = configuration["EmailSetting:Username"];
            var password = configuration["EmailSetting:Password"];

            if (string.IsNullOrEmpty(smtpHost) ||
                string.IsNullOrEmpty(portString) ||
                string.IsNullOrEmpty(fromAddress) ||
                string.IsNullOrEmpty(username) ||
                string.IsNullOrEmpty(password))
            {
                // One or more email settings are missing in appsettings.json
                // Log this error or throw a more specific exception
                throw new InvalidOperationException("Email settings are not configured properly in appsettings.json");
            }

            if (!int.TryParse(portString, out var port))
            {
                throw new InvalidOperationException($"The configured port '{portString}' is not a valid integer.");
            }
            // --- defensive coding ends here ---


            MimeMessage message = new MimeMessage();
            message.From.Add(new MailboxAddress("Sawaaly",configuration["EmailSetting:From"]));
            message.Subject = emailDTO.Subject;
            message.To.Add(new MailboxAddress(emailDTO.To, emailDTO.To));
            message.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = emailDTO.Contect
            };
            using (var smtp = new MailKit.Net.Smtp.SmtpClient())
            {
                try
                {
                    await smtp.ConnectAsync(smtpHost, port, true);
                    await smtp.AuthenticateAsync(username, password);
                    await smtp.SendAsync(message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to send email: {ex.Message}");
                    throw;

                }
                finally 
                {
                    smtp.Disconnect(true);
                    smtp.Dispose();
                }
            }
        }
    }
}
