using AzureForum.Data.Contracts;
using AzureForum.Data.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AzureForum.Data
{
    public static class ServiceConfigurator
    {
        public static void RegisterDataModule(this IServiceCollection services)
        {
            services.AddScoped<IDataService, DataService>();
        }
    }
}