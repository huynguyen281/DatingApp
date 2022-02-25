using DatingApp.API.Database;
using DatingApp.API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DatingApp.API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection service, IConfiguration config)
        {
            service.AddScoped<ITokenService, TokenService>();

            // Connect SQLSERVER
            var connectionString = config.GetConnectionString("DefaultConnection");
            service.AddDbContext<DataContext>(options =>
                options.UseSqlServer(connectionString));

            return service;
        }
    }
}