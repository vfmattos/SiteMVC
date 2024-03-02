using Microsoft.Extensions.Options;
using MimeKit;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MailKit.Net.Smtp;

namespace SiteMVC.Helper
{
    public class EmailServico : IEmailServico
    {

        public Task SendEmailAsync(string toEmail, string subject, string htmlBody)
        {
            var message = new MimeMessage();
            message.From.Add(MailboxAddress.Parse("vitorfmattos03@outlook.com"));
            message.To.Add(MailboxAddress.Parse(toEmail));
            message.Subject = subject;

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = htmlBody;
            message.Body = bodyBuilder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                client.Connect("smtp-mail.outlook.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                client.Authenticate("vitorfmattos03@outlook.com", "Vitor9812223841998");
                client.Send(message);
                client.Disconnect(true);
            }

            return Task.CompletedTask;
        }
    }

}

