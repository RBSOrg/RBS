using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RBS.Data.Abstractions;
using RBS.Data.Implementations;

namespace RBS.Data
{
    public static class DependenceInjection
    {
        public static void AddData(this IServiceCollection services, IConfiguration configuration)
        {
            //Repositorys

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserTokenRepository, UserTokenRepository>();
        }
    }
}
