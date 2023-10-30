using System;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using DependencyInjectionDemo.Services.Counter;
using DependencyInjectionDemo.Services.Save;

namespace DependencyInjectionDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IServiceProvider _serviceProvider;

        // Inject the IServiceProvider to resolve other services or windows.
        public MainWindow(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        private void OpenWindow_Click(object sender, RoutedEventArgs e)
        {
            // Resolve ICounterService and ISaveService from the DI container.
            var counterService = _serviceProvider.GetRequiredService<ICounterService>();
            var saveService = _serviceProvider.GetRequiredService<ISaveService>();

            // Pass the resolved services to SampleWindow's constructor.
            var sampleWindow = new SampleWindow(counterService, saveService);
            sampleWindow.Show();
        }
    }
}