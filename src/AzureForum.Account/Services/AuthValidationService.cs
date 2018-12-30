using AzureForum.Account.Models;
using AzureForum.Common.Exceptions;
using AzureForum.Data.Contracts;
using System.Net.Mail;
using System.Threading.Tasks;
using AzureForum.Account.Contracts;
using AzureForum.Data.Models.Account;
using Microsoft.EntityFrameworkCore;

namespace AzureForum.Account.Services
{
    public class AuthValidationService: IAuthValidationService
    {
        private readonly IDataService _dataService;

        public AuthValidationService(IDataService dataService)
        {
            _dataService = dataService;
        }

        public async Task ValidateRegisterViewModel(RegisterViewModel model)
        {
            try
            {
                var email = new MailAddress(model.Email);
            }
            catch
            {
                throw new RegistrationFailedException(
                    $"Email address is invalid!");
            }

            var userWithSameEmail = await _dataService.GetSet<AzureForumUser>().FirstOrDefaultAsync(x => x.Email == model.Email);
            if (userWithSameEmail != null)
            {
                throw new RegistrationFailedException(
                    $"Account with this email address already exists!");
            }

            if (string.IsNullOrEmpty(model.Password))
            {
                throw new RegistrationFailedException(
                    $"Password cannot be null or empty!");
            }

            if (string.IsNullOrEmpty(model.UserName))
            {
                throw new RegistrationFailedException(
                    $"UserName cannot be null or empty!");
            }
        }

        public Task ValidateSignInViewModel(SignInViewModel model)
        {
            if (string.IsNullOrEmpty(model.Password))
            {
                throw new SignInFailedException(
                    $"Password cannot be null or empty!");
            }

            if (string.IsNullOrEmpty(model.UserName))
            {
                throw new SignInFailedException(
                    $"UserName cannot be null or empty!");
            }

            return Task.CompletedTask;
        }
    }
}
