using MicroEventDb.LoadObjectFromFile;
using nJsDb.LoadObjectFromFile;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                stream.Position = page.Position();
                stream.Write(array, 0, array.Length);
            }
        }
    }
}
