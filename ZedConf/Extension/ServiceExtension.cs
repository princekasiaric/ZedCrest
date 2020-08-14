using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using ZedConf.Core.Mapping;
using ZedConf.Core.Services;
using ZedConf.Core.Services.Implementation;
using ZedConf.Persistence.Repository;
using ZedConf.Persistence.Repository.Implementation;
using ZedConf.Persistence.UnitOfWork;
using ZedConf.Persistence.UnitOfWork.Implementation;

namespace ZedConf.Extension
{
    public static class ServiceExtension
    {
        public static void ConfigureRepository(this IServiceCollection services)
        {
            services.AddScoped<ITalkRepo, TalkRepo>();
            services.AddScoped<ISpeakerRepo, SpeakerRepo>();
            services.AddScoped<IAttendeeRepo, AttendeeRepo>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static void ConfigureAPICore(this IServiceCollection services)
        {
            services.AddScoped<ITalkService, TalkService>();
            services.AddScoped<ISpeakerService, SpeakerService>();
            services.AddScoped<IAttendeeService, AttendeeService>();
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
