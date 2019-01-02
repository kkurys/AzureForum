using AzureForum.Account.Contracts;
using AzureForum.Account.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AzureForum.Account
{
    public static class ServiceConfigurator
    {
        public static void RegisterAccountModule(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IAuthValidationService, AuthValidationService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}