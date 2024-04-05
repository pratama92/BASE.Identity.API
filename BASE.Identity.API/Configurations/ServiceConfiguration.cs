using BASE.Identity.Repository.Repositories;
using BASE.Identity.Services.Interfaces;
using BASE.Identity.Services.Services;

namespace HMRS.Identity.API.Configurations
{
    public static class ServiceConfiguration
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            /* Example */
            //services.AddScoped<IEmployeeService, EmployeeService>();

            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IUserService, UserService>();

            services.AddDbContext<DataBaseContext>();

        }

    }
}
