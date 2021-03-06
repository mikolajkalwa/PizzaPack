using api.Configuration;
using api.Database;
using api.Helpers;
using api.Models;
using api.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Serilog;

namespace api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => options.Filters.Add(typeof(ExceptionFilter)));
            services.Configure<DatabaseSettings>(
                Configuration.GetSection(nameof(DatabaseSettings))
            );

            services.AddSingleton<IDatabaseSettings>(provider =>
                provider.GetRequiredService<IOptions<DatabaseSettings>>().Value
            );

            services.Configure<SendGridSettings>(
                Configuration.GetSection(nameof(SendGridSettings))
            );

            services.AddSingleton<ISendGridSettings>(provider =>
                provider.GetRequiredService<IOptions<SendGridSettings>>().Value
            );

            services.AddSingleton<IMongo, Mongo>();

            services.AddScoped<IMenuService, MenuService>();
            services.AddScoped<IOrdersService, OrdersService>();
            services.AddScoped<INotificationService, SendGridService>();
            services.AddScoped<IOrdersServiceHelpers, OrdersServiceHelpers>();

            services.Decorate<IOrdersService, OrdersNotificationService>();

            services.AddControllers();

            services.AddHealthChecks()
                .AddMongoDb(Configuration["DatabaseSettings:ConnectionString"]);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSerilogRequestLogging();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
            });
        }
    }
}
