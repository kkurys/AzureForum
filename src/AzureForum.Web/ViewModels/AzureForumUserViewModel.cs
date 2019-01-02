using AzureForum.Data.Models.Account;

namespace AzureForum.Web.ViewModels
{
    public class AzureForumUserViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        public AzureForumUserViewModel(AzureForumUser user)
        {
            Id = user.Id.ToString();
            UserName = user.UserName;
            Email = user.Email;
        }
    }
}
