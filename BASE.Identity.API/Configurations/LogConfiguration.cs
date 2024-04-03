using Serilog.Events;
using Serilog;

namespace HMRS.Identity.API.Configurations
{
    public static class LogConfiguration
    {
        public static void ConfigureLog(this IServiceCollection services)
        {
            Log.Logger = new LoggerConfiguration()
               .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
               .WriteTo.Console()
               .WriteTo.File("../Log/HMRS.Identiry.API/HMRS.Identity-log.txt", rollingInterval: RollingInterval.Day)
               //.WriteTo.File(new JsonFormatter(), "log.txt")
               .CreateLogger();
        }
    }
}
