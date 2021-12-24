using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using web_api.Data;
using web_api.Interface;
using web_api.services;

namespace web_api.Extenstion
{
    public static class ApplicationServicesExtention
    {
        public static IServiceCollection AddApplicationservice(this IServiceCollection services, IConfiguration config){
            
            services.AddScoped<ITokenService, TokenService>();
            
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });

            return services;
        }
        
    }
}