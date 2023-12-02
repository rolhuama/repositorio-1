using ColabManager360.Domain.Configurations;

namespace ColabManager360.Api.Configurations
{
    public static class ConfigureSettings
    {
        public static IServiceCollection AddConfigureSettings(this IServiceCollection services, IConfiguration configuration)
        {            
            services.Configure<JwtConfig>(configuration.GetSection("Jwt"));

            return services;
        }
    }
}
