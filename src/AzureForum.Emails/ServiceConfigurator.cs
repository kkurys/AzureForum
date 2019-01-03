using AzureForum.Emails.Contracts;
using AzureForum.Emails.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AzureForum.Emails
{
    public static class ServiceConfigurator
    {
        public static void RegisterEmailsModule(this IServiceCollection services)
        {
            services.AddScoped<IEmailService, SendGridEmailService>();
        }
    }
}
