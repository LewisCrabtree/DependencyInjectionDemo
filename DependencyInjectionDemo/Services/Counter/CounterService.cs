using System;
using DependencyInjectionDemo.Configuration;
using Microsoft.Extensions.Options;

namespace DependencyInjectionDemo.Services.Counter
{
    internal class CounterService : ICounterService
    {
        private readonly int _increment;

        private int _counter;
        public int Counter => _counter;

        public event Action? CounterChanged;

        public CounterService(IOptions<CounterConfiguration> config)
        {
            _increment = config.Value.Increment;
        }

        public void IncrementCounter()
        {
            _counter += _increment;
            CounterChanged?.Invoke();
        }
    }
}