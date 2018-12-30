using AzureForum.Account.Models;
using System.Threading.Tasks;

namespace AzureForum.Account.Contracts
{
    public interface IAuthService
    {
        Task<string> Register(RegisterViewModel model);
        Task<string> SignIn(SignInViewModel model);
    }
}
