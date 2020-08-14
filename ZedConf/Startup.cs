using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using ZedConf.Extension;
using ZedConf.Persistence;
using ZedConf.Settings;

namespace ZedConf
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var configSection = _config.GetSection("AppSettings");
            services.Configure<AppSettings>(configSection);
            var settings = configSection.Get<AppSettings>();

            var connString = settings.ConnectionString.Default;
            services.AddDbContext<ZedConfDbContext>(opt => opt.UseSqlServer(connString));

            services.ConfigureRepository();
            services.ConfigureAPICore();
            services.ConfigureAutomapper();

            services.AddControllers()
                    .AddFluentValidation()
                    .AddNewtonsoftJson(options => 
                                       options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore); 
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSerilogRequestLogging();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
