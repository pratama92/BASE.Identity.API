using HMRS.Identity.Services.Interfaces;
using HMRS.Identity.Services.Services;

namespace HMRS.Identity.API.Configurations
{
    public static class ServiceConfiguration
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            /* Example */
            //services.AddScoped<IEmployeeService, EmployeeService>();

            services.AddScoped<ILoginService, LoginService>();
        }

    }
}
