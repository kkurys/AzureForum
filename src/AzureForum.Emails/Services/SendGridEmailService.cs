using AzureForum.Data.Models.Account;
using AzureForum.Emails.Contracts;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace AzureForum.Emails.Services
{
    public class SendGridEmailService: IEmailService
    {
        public async Task SendEmail(AzureForumUser to, string subject, string content)
        {
            var apiKey = System.Environment.GetEnvironmentVariable("SENDGRID_APIKEY");
            if (string.IsNullOrEmpty(apiKey))
            {
                return;
            }

            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("powiadomienia@forum.tar.com", "MOKK Team"),
                Subject = subject,
                HtmlContent = content
            };

            msg.AddTo(new EmailAddress(to.Email, to.UserName));

            await client.SendEmailAsync(msg);
        }
    }
}
