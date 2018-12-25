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

        private List<object> _entities;

        public EngineDb(string filePath)
        {
            _filePath = filePath;
            _storePageInFile = new StorePageInFile(filePath);
            _metaPageManager = new MetaPageManager(filePath);
            _loadPageFromFile = new LoadPageFromFile(filePath);
            _entities = new List<object>();
        }

        public void AddEntity(object entity)
        {
            _entities.Add(entity);
        }

        public void SaveAll()
        {
            var storePageInFile = new StorePageInFile(_filePath);
            using (var stream = _storePageInFile.OpenFile())
            {
                foreach (var entity in _entities)
                {
                    var data = ByteHelper.ObjectToByteArray(entity);
                    _storePageInFile.StoreIntoFile(stream, new Page(_metaPageManager.CreatePosition(), data));
                }

                _storePageInFile.StoreIntoFile(stream, _metaPageManager.GetPage());
            }
        }

        // Create one thread by read.
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
