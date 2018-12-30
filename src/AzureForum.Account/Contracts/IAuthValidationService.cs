using System.Threading.Tasks;
using AzureForum.Account.Models;

namespace AzureForum.Account.Contracts
{
    public interface IAuthValidationService
    {
        Task ValidateRegisterViewModel(RegisterViewModel model);
        Task ValidateSignInViewModel(SignInViewModel model);
    }
}
