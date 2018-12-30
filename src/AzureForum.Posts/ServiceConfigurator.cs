using Microsoft.Extensions.DependencyInjection;

namespace AzureForum.Posts
{
    public static class ServiceConfigurator
    {
        public static void RegisterPostsModule(this IServiceCollection services)
        {
            services.AddScoped<IPostsService, PostsService>();
        }
    }
}
