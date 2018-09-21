using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace nJsDb.LoadObjectFromFile
{
    public class Engine
    {
        private string _filePath;


        public Engine(string filePath)
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

            // Convert object to byte array
            using (FileStream stream = File.Open(_filePath, FileMode.OpenOrCreate))
            {
                formatter.Serialize(stream, entity);
            }

            
            // Open file

            // Add byte array on the file
        }
    }
}
