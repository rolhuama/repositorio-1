namespace ColabManager360.Api.Configurations
{
    public static class CorsConfiguration
    {
        public static IServiceCollection AddCorsConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("ColabManager360CorsPolicy", builder =>
                {

                    // Configuración más restrictiva en producción para múltiples dominios
                    string[] allowedOrigins = configuration.GetSection("Cors:AllowedOrigins").Get<string[]>();
                    builder.WithOrigins(allowedOrigins)
                           .AllowAnyHeader()
                           .AllowAnyMethod()
                           .AllowCredentials();
                   
                });
          

            });

            return services;
        }
    }
}
