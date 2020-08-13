using Microsoft.Extensions.DependencyInjection;
using ZedConf.Persistence;

namespace ZedConf.Extension
{
    public static class ServiceExtension
    {
        public static void ConfigureRepository(this IServiceCollection services)
        {

        }

        public static void ConfigureDbContext(this IServiceCollection services)
        {
            services.AddDbContext<ZedConfDbContext>(opt =>
            {
                
            });
        }

        public static void ConfigureAPICore(this IServiceCollection services)
        {

        }

        public static void ConfigureAutomapper(this IServiceCollection services)
        {

        }
    }
}
