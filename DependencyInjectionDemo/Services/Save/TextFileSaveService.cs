using System.IO;

namespace DependencyInjectionDemo.Services.Save
{
    internal class TextFileSaveService : SaveService
    {
        protected override string Extension => "txt";

        public override void Save(int count)
        {
            File.WriteAllText(FileName, count.ToString());
        }
    }
}