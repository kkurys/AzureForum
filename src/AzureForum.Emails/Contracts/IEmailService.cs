using System.Threading.Tasks;
using AzureForum.Data.Models.Account;

namespace AzureForum.Emails.Contracts
{
    public interface IEmailService
    {
        Task SendEmail(AzureForumUser to, string subject, string content);
    }
}
