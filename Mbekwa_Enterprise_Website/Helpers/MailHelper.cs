using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace Mbekwa_Enterprise_Website.Helpers
{
    public class MailHelper
    {
        public static bool Send(string fromAddress, string toAddress, string subject, string message)
        {
            try
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");

                var configuration = builder.Build();
                var host = configuration["EmailSettings:Host"];
                var port = int.Parse(configuration["EmailSettings:Port"]);
                var username = configuration["EmailSettings:Username"];
                var password = configuration["EmailSettings:Password"];
                var enable = bool.Parse(configuration["EmailSettings:SMTP:starttls:enable"]);

                var smtpClient = new SmtpClient()
                {
                    Host = host,
                    Port = port,
                    EnableSsl = enable,
                    Credentials = new NetworkCredential(username, password)
                };

                var content = new MailMessage(fromAddress, toAddress);
                content.Subject = subject;
                content.Body = message;
                content.IsBodyHtml = true;

                smtpClient.Send(content);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
