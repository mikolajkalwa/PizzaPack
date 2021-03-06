using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using FluentValidation;
using gui.ApiClient;
using gui.Models;

namespace gui
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("PL");


            var services = new ServiceCollection();
            ConfigureServices(services);
            using (var serviceProvider = services.BuildServiceProvider())
            {
                var mainForm = serviceProvider.GetRequiredService<MainForm>();
                Application.Run(mainForm);
            }
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            var configuration = new ConfigurationBuilder().SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", false).Build();


            services.Configure<AppSettings>(configuration.GetSection("AppSettings"));
            services.AddSingleton<AppState>();
            services.AddSingleton<OrderHelpers>();
            services.AddScoped<IPizzeriaApiClient, PizzeriaApiClient>();
            services.AddScoped<MainForm>();
        }
    }
}
