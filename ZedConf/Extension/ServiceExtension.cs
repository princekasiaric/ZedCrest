using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using ZedConf.Core.Mapping;
using ZedConf.Persistence;
using ZedConf.Persistence.Repository;
using ZedConf.Persistence.Repository.Implementation;

namespace ZedConf.Extension
{
    public static class ServiceExtension
    {
        public static void ConfigureRepository(this IServiceCollection services)
        {
            services.AddScoped<ITalkRepo, TalkRepo>();
            services.AddScoped<ISpeakerRepo, SpeakerRepo>();
            services.AddScoped<IAttendeeRepo, AttendeeRepo>();
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
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            services.AddSingleton(c => config.CreateMapper());
        }
    }
}
