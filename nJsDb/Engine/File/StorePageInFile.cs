using MicroEventDb.LoadObjectFromFile;
using nJsDb.LoadObjectFromFile;
using System.IO;

namespace MicroEventDb.Engine
{
    public class StorePageInFile
    {
        private readonly string _filePath;

        public StorePageInFile(string filePath)
        {
            _filePath = filePath;
        }

        public void StoreIntoFile(Page page)
        {
            FileInfo fileInfo = new FileInfo(_filePath);

            if (!fileInfo.Exists)
                Directory.CreateDirectory(fileInfo.Directory.FullName);

            using (var stream = File.Open(_filePath, FileMode.OpenOrCreate))
            {
                var array = ByteHelper.ObjectToByteArray(page);
                
                // Set the good position
                stream.Position = page.Position() * Page.Size;

                stream.Write(array, 0, array.Length);
            }
        }
    }
}
