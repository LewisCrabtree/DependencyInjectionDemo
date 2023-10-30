using System.Windows;
using DependencyInjectionDemo.Configuration;
using DependencyInjectionDemo.Services.Counter;
using DependencyInjectionDemo.Services.Save;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DependencyInjectionDemo
{
    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
        {
            _host = new HostBuilder()
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.AddJsonFile("appsettings.json", optional: false);
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.Configure<CounterConfiguration>(hostContext.Configuration.GetSection("CounterConfiguration"));

                    // Register services
                    services.AddSingleton<ICounterService, CounterService>(); // AddSingleton, AddTransient
                    services.AddSingleton<ISaveService, JsonFileSaveService>(); // or JsonFileSaveService or NoOpSaveService
                })
                .Build();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var mainWindow = new MainWindow(_host.Services);
            mainWindow.Show();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            _host.Dispose();
        }
    }
}