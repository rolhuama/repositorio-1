using ColabManager360.Aplication.Services.Account;
using ColabManager360.Aplication.Services.Activity;
using ColabManager360.Aplication.Services.Helper;
using ColabManager360.Aplication.Services.Reports;
using ColabManager360.Aplication.Services.Security;


namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ISecurityService, SecurityService>();
            services.AddScoped<IHelperService, HelperService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IActivityService, ActivityService>();
            services.AddScoped<IReportService, ReportService>();


            return services;
        }
    }
}
