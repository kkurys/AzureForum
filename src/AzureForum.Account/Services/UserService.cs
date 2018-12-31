using AzureForum.Data.Contracts;
using AzureForum.Data.Models.Account;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using AzureForum.Account.Contracts;

namespace AzureForum.Account.Services
{
    public class UserService: IUserService
    {
        private readonly UserManager<AzureForumUser> _userManager;

        public UserService(
            UserManager<AzureForumUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<AzureForumUser> GetUserByIdAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            return user;
        }

        public async Task<AzureForumUser> GetUserByNameAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            return user;
        }
    }
}
