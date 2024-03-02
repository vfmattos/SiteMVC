using System.Threading.Tasks;

namespace SiteMVC.Helper
{
    public interface IEmailServico
    {

        Task SendEmailAsync(string toEmail, string subject, string htmlBody);

    }
}
