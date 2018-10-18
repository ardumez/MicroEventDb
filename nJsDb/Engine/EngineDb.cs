using MicroEventDb.Engine;
using MicroEventDb.LoadObjectFromFile;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace nJsDb.LoadObjectFromFile
{
    public class EngineDb
    {
        private readonly string _filePath;
        private readonly FreeSpaces _freeSpaces;

        public EngineDb(string filePath)
        {
            _filePath = filePath;
            _freeSpaces = new FreeSpaces(1000, filePath);
        }

        public object LoadObject()
        {
            throw new NotImplementedException();
        }

        public void AddEntity(object entity)
        {
            IFormatter formatter = new BinaryFormatter();

            // Convert object to bjson
            var data = ByteHelper.ObjectToByteArray(entity);

            List<byte[]> fragments = ByteHelper.Split(data, (Page.EmptySize));

            // Convert fragment to page byte
            List<Page> pages = new List<Page>();

            var freePositions = _freeSpaces.GetFreeSpace();

            for (int i = 0; i < fragments.Count; i++)
            {
                var nextPosition = freePositions[i + 1];

                if (i == fragments.Count)
                    nextPosition = -1;

                pages.Add(new Page(freePositions[i], fragments[i], nextPosition));
            }

            FileInfo fileInfo = new FileInfo(_filePath);

            if (!fileInfo.Exists)
                Directory.CreateDirectory(fileInfo.Directory.FullName);

            using (var stream = File.Open(_filePath, FileMode.OpenOrCreate))
            {
                foreach (var page in pages)
                {
                    // Assuming data is the data you want to write to the file
                    stream.Write(ByteHelper.ObjectToByteArray(page), page.Position(), Page.EmptySize);
                }
            }
        }
    }
}
