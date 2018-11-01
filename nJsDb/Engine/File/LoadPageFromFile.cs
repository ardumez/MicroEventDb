using MicroEventDb.LoadObjectFromFile;
using nJsDb.LoadObjectFromFile;
using System.IO;

namespace MicroEventDb.Engine
{
    public class LoadPageFromFile
    {
        public string _path;

        public LoadPageFromFile(string path)
        {
            _path = path;
        }

        public Page ReadPage(int position)
        {
            string path = string.Empty;
            byte[] pageBytes = new byte[Page.Size];

            using (MemoryStream writer = new MemoryStream())
            {
                using (Stream source = File.OpenRead(_path))
                {
                    byte[] buffer = new byte[2048];
                    int bytesRead;

                    // Set the good position
                    source.Position = position * Page.Size;

                    while ((bytesRead = source.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        writer.Write(buffer, 0, bytesRead);
                    }
                    pageBytes = writer.ToArray();
                }
            }
            return ByteHelper.Deserialize<Page>(pageBytes);
        }
    }
}
