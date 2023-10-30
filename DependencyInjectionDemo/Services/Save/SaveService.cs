using System;

namespace DependencyInjectionDemo.Services.Save
{
    internal abstract class SaveService : ISaveService
    {
        private Guid Guid { get; } = Guid.NewGuid();

        protected string FileName => $"Count_{Guid}.{Extension}";

        protected abstract string Extension { get; }

        public abstract void Save(int count);
    }
}
