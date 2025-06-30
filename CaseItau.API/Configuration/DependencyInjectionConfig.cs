using CaseItau.Domain.Interfaces;
using CaseItau.Domain.Notificacoes;
using CaseItau.Domain.Services;
using CaseItau.Infra.Repositories;

namespace CaseItau.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<IFundoService, FundoService>();
            services.AddTransient<IFundoRepository, FundoRepository>();

            return services;
        }
    }
}
