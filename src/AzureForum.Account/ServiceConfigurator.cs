using Microsoft.Extensions.DependencyInjection;

namespace AzureForum.Account
{
    public static class ServiceConfigurator
    {
        public static void RegisterAccountModule(this IServiceCollection services)
        {
            // services.AddScoped<IDataService, DataService>();
        }
    }
}