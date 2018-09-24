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
        private string _filePath;

        public EngineDb(string filePath)
        {
            this._filePath = filePath;
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

            var pages = new List<Page>();

            int position = 0;
            int lastPosition = fragments.Count;

            using (var stream = File.Open(_filePath, FileMode.OpenOrCreate))
            {
                foreach (var fragment in fragments)
                {
                    var nextPosition = position + 1;

                    if (position == lastPosition)
                    {
                        nextPosition = -1;
                    }

                    var page = new Page(position, fragment, nextPosition);

                    var pageBytes = ByteHelper.ObjectToByteArray(page);

                    stream.Position = position;
                    // Assuming data is the data you want to write to the file
                    stream.Write(data, 0, data.Length);
                }

                position += data.Length;           
            }
        }
    }
}
