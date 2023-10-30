using System;
using System.Windows;
using DependencyInjectionDemo.Services.Counter;
using DependencyInjectionDemo.Services.Save;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjectionDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IServiceProvider _serviceProvider;

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

            var sampleWindow = new SampleWindow(counterService, saveService);
            sampleWindow.Show();
        }
    }
}
