namespace DependencyInjectionDemo.Services.Save
{
    /// <summary>
    /// SaveService stub for unit testing.
    /// </summary>
    internal class NoOpSaveService : SaveService
    {
        protected override string Extension => string.Empty;

        public override void Save(int count)
        {
            // Do nothing.
        }
    }
}