using ChargeIT.Application.Contracts;
using ChargeIT.Application.Handlers;

namespace ChargeIT.WebAPI {

    public static class ConfigureService {
        public static IServiceCollection AddWebAPIServices(this IServiceCollection services, IConfiguration configuration) {
            services.AddScoped<IChargeMachineCommand, ChargeMachineCommand>();
            services.AddScoped<IChargeMachineQuery, ChargeMachineQuery>();

            return services;
        }
    }

}