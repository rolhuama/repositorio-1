namespace ColabManager360.Api.Configurations
{
    public static class ConfigureCache
    {
        public static IServiceCollection AddConfigureCache(this IServiceCollection services)
        {
            services.AddOutputCache(o => {
                o.AddPolicy("AccountLists", p => p.Expire(TimeSpan.FromHours(24)).Tag("AccountLists"));
                o.AddPolicy("Departments", p => p.Expire(TimeSpan.FromHours(24)).Tag("Departments"));
                o.AddPolicy("Provinces", p => p.Expire(TimeSpan.FromHours(24)).Tag("Provinces"));
                o.AddPolicy("Districts", p => p.Expire(TimeSpan.FromHours(24)).Tag("Districts"));
                o.AddPolicy("Countries", p => p.Expire(TimeSpan.FromHours(24)).Tag("Countries"));
                o.AddPolicy("Countries", p => p.Expire(TimeSpan.FromHours(24)).Tag("MasterTableList"));
                o.AddPolicy("ServiceTypes", p => p.Expire(TimeSpan.FromHours(24)).Tag("ServiceTypes"));
                o.AddPolicy("CompanyServicesList", p => p.Expire(TimeSpan.FromHours(24)).Tag("CompanyServicesList"));
                o.AddPolicy("CompanyActivityTypeList", p => p.Expire(TimeSpan.FromHours(24)).Tag("CompanyActivityTypeList"));

            });

            return services;
        }
    }
}
