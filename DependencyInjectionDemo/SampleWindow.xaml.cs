using System;
using System.Windows;
using DependencyInjectionDemo.Services.Counter;
using DependencyInjectionDemo.Services.Save;

namespace DependencyInjectionDemo
{
    public partial class SampleWindow : Window
    {
        private readonly ICounterService _counterService;
        private readonly ISaveService _saveService;

        public SampleWindow(ICounterService counterService, ISaveService saveService)
        {
            InitializeComponent();
            _counterService = counterService;
            _saveService = saveService;

            // Update UI when counter changes.
            _counterService.CounterChanged += UpdateCounterDisplay;

            UpdateCounterDisplay();
        }

        private void UpdateCounterDisplay()
        {
            CounterTextBlock.Text = $"Counter: {_counterService.Counter}";
        }

        private void IncrementCounter_Click(object sender, RoutedEventArgs e)
        {
            _counterService.IncrementCounter();
        }

        private void SaveCounter_Click(object sender, RoutedEventArgs e)
        {
            _saveService.Save(_counterService.Counter);
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            _counterService.CounterChanged -= UpdateCounterDisplay;
        }
    }
}
