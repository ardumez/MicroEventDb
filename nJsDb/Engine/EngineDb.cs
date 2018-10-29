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
        private MetaPage _metaPage;
        private StorePageInFile _storePageInFile;

        public EngineDb(string filePath)
        {
            _filePath = filePath;
            _freeSpaces = new FreeSpaces(1000, filePath);
            _storePageInFile = new StorePageInFile(_filePath);

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

            _storePageInFile.StoreIntoFile(new Page(_metaPage.LastPosition, data));

            _metaPage.LastPosition++;
            _metaPage.NumberPages++;
            SaveMetaPage(_metaPage);
        }

        private void SaveMetaPage(MetaPage metaPage)
        {
            var data = ByteHelper.ObjectToByteArray(_metaPage);

            _storePageInFile.StoreIntoFile(new Page(0, data));
        }

        public bool LastPageIsFull()
        {
            return true;
        }
    }
}
