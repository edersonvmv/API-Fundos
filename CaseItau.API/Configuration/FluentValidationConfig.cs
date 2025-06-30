using CaseItau.API.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace CaseItau.API.Configuration
{
    public static class FluentValidationConfig
    {
        public static IServiceCollection AddFluentValidation(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<ParametroFundoViewModelValidator>();
            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();

            return services;
        }
    }
}
