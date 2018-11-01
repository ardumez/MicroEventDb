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
        private StorePageInFile _storePageInFile;
        private MetaPageManager _metaPageManager;
        private LoadPageFromFile _loadPageFromFile;

        public EngineDb(string filePath)
        {
            _filePath = filePath;
            _storePageInFile = new StorePageInFile(filePath);
            _metaPageManager = new MetaPageManager(filePath);
            _loadPageFromFile = new LoadPageFromFile(filePath);
        }

        public void AddEntity(object entity)
        {
            IFormatter formatter = new BinaryFormatter();

            // Convert object to bjson
            var data = ByteHelper.ObjectToByteArray(entity);

            _storePageInFile.StoreIntoFile(new Page(_metaPageManager.CreatePosition(), data));
        }

        public TEntity Find<TEntity>(int position)
        {
            return _loadPageFromFile.ReadPage(position).Data<TEntity>();
        }

        public bool LastPageIsFull()
        {
            return true;
        }
    }
}
