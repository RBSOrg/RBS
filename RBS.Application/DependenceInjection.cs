using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RBS.Application.Abstractions;
using RBS.Application.Implementations;

namespace RBS.Application
{
    public static class DependenceInjection
    {
        public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            //Services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IJwtAuthManager, JwtAuthManager>();
        }
    }
}
