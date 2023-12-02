using ColabManager360.Domain.Entities.Security.Models;
using ColabManager360.Domain.Interfaces.Account;
using ColabManager360.Domain.Interfaces.Activity;
using ColabManager360.Domain.Interfaces.Helper;
using ColabManager360.Domain.Interfaces.Reports;
using ColabManager360.Domain.Interfaces.Security;
using ColabManager360.Infrastructure;
using ColabManager360.Infrastructure.Data;
using ColabManager360.Infrastructure.Repositories.Account;
using ColabManager360.Infrastructure.Repositories.Activity;
using ColabManager360.Infrastructure.Repositories.Helper;
using ColabManager360.Infrastructure.Repositories.Identity;
using ColabManager360.Infrastructure.Repositories.Reports;
using ColabManager360.Infrastructure.Repositories.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection;


//namespace ColabManager360.Infrastructure
//{
public static class DependencyInjection
{
    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddAutoMapper(typeof(MappingProfile));

        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("SQLServer")));

        #region Identity Configuration    
        services.AddIdentity<Users, Roles>().AddEntityFrameworkStores<ApplicationDbContext>();
        services.AddScoped<UserManager<Users>>();
        services.AddScoped<SignInManager<Users>>();
        services.ConfigureApplicationCookie(options =>
        {
            options.Cookie.Name = "ColabManager360"; // Cambia el nombre aquí, el nombre es estatico para poder borrar la cookie de identity
            options.ExpireTimeSpan = TimeSpan.FromSeconds(1);
            options.Cookie.HttpOnly = true;
            options.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.SameAsRequest;
            options.Cookie.IsEssential = true;
            options.Cookie.SameSite = AspNetCore.Http.SameSiteMode.None;
        });

        #endregion


        #region Repository / Services Configuration    
        services.AddScoped<IIdentityService, IdentityService>();
        services.AddScoped<ISecurityRepository, SecurityRepository>();
        services.AddScoped<IHelperRepository, HelperRepository>();
        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddScoped<IActivityRepository, ActivityRepository>();
        services.AddScoped<IReportRepository, ReportRepository>();
        #endregion

    }
}
//}
