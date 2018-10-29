using nJsDb.LoadObjectFromFile;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

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

                    while ((bytesRead = source.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        writer.Write(buffer, 0, bytesRead);
                    }

                    pageBytes = writer.ToArray();
                }
            }

            return Deserialize<Page>(pageBytes);
        }

        private T Deserialize<T>(byte[] param)
        {
            using (MemoryStream ms = new MemoryStream(param))
            {
                IFormatter br = new BinaryFormatter();
                return (T)br.Deserialize(ms);
            }
        }
    }
}
