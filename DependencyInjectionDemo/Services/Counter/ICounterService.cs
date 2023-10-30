using System;

namespace DependencyInjectionDemo.Services.Counter
{
    public interface ICounterService
    {
        int Counter { get; }

        event Action CounterChanged;

        void IncrementCounter();
    }
}
