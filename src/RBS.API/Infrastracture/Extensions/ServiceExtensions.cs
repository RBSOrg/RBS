using Microsoft.EntityFrameworkCore;
using RBS.Application.Models;
using RBS.PersistenceDB.Context;

namespace RBS.Api.Infrastracture.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtTokenConfig = configuration.GetSection("jwtTokenConfig").Get<JwtTokenConfig>();
            services.AddSingleton(jwtTokenConfig);

            services.AddDbContext<RBSDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("RBSConnection")));
        }
    }
}
