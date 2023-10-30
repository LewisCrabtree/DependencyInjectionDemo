using System.IO;
using System.Text.Json;

namespace DependencyInjectionDemo.Services.Save
{
    internal class JsonFileSaveService : SaveService
    {
        protected override string Extension => "json";

        public override void Save(int count)
        {
            var json = JsonSerializer.Serialize(new { Count = count });
            File.WriteAllText(FileName, json);
        }
    }
}
