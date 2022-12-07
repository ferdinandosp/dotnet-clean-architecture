using Microsoft.Extensions.DependencyInjection;

namespace MyApp.Application.DependencyResolver
{
    public static class DependencyResolverService
    {
        public static void Register(IServiceCollection services)
        {
            //services.AddScoped<IUserService, UserService>();
        }
    }
}