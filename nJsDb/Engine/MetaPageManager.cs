using MicroEventDb.LoadObjectFromFile;
using nJsDb.LoadObjectFromFile;
using System;
using System.IO;

namespace MicroEventDb.Engine
{
    /// <summary>
    /// Meta Page contains last position in file, and number of page
    /// </summary>
    public class MetaPageManager
    {
        private MetaPage _metaPage;

        private StorePageInFile _storePageInFile;

        public MetaPageManager(string filePath)
        {
            _storePageInFile = new StorePageInFile(filePath);

            CreateMetaPageIfNotExist(_storePageInFile, filePath);
            try
            {
                _metaPage = new LoadPageFromFile(filePath).ReadPage(0).Data<MetaPage>();
            }
            catch (InvalidCastException)
            {
                throw new FileCorruptionException("Unable to load meta page, file is corrupt");
            }
        }

        public int CreatePosition()
        {
            _metaPage.LastPosition++;
            _metaPage.NumberPages++;
            SaveMetaPage(_metaPage);
            return _metaPage.LastPosition - 1;
        }

        private void SaveMetaPage(MetaPage metaPage)
        {
            var data = ByteHelper.ObjectToByteArray(_metaPage);

            _storePageInFile.StoreIntoFile(new Page(0, data));
        }

        private void CreateMetaPageIfNotExist(StorePageInFile storePageInFile, string filePath)
        {
            FileInfo fileInfo = new FileInfo(filePath);

            if (!fileInfo.Exists)
            {
                var data = ByteHelper.ObjectToByteArray(new MetaPage() { LastPosition = 1, NumberPages = 1 });
                storePageInFile.StoreIntoFile(new Page(0, data));
            }
        }
    }
}
