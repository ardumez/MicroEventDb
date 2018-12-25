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

        public FileStream OpenFile()
        {
            FileInfo fileInfo = new FileInfo(_filePath);
            if (!fileInfo.Exists) Directory.CreateDirectory(fileInfo.Directory.FullName);
            return File.Open(_filePath, FileMode.OpenOrCreate);
        }

        public void StoreIntoFile(FileStream stream, Page page)
        {  
            var array = ByteHelper.ObjectToByteArray(page);
            stream.Position = page.Position() * Page.Size;
            stream.Write(array, 0, array.Length);   
        }
    }
}
