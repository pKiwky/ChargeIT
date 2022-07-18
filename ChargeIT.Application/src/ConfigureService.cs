using System.Reflection;
using ChargeIT.Application.Contracts.Data;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ChargeIT.Application {

    public static class ConfigureService {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration) {
            return services;
        }
    }

}