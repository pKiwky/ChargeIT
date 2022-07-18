using ChargeIT.Application.Contracts.Data;
using ChargeIT.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ChargeIT.Infrastructure {

    public static class ConfigureService {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration) {
            services.AddDbContext<ApplicationDbContext>(options => { options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")); });

            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

            return services;
        }
    }

}