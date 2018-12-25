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

        public MetaPageManager(string filePath)
        {
            if (FileIsNew(filePath))
            {
                _metaPage = CreateFirstMetaPage();
            }
            else
            {
                try
                {
                    _metaPage = new LoadPageFromFile(filePath).ReadPage(0).Data<MetaPage>();
                }
                catch (InvalidCastException)
                {
                    throw new FileCorruptionException("Unable to load meta page, file is corrupt");
                }
            }
        }

        public int CreatePosition()
        {
            _metaPage.LastPosition++;
            _metaPage.NumberPages++;
            return _metaPage.LastPosition - 1;
        }

        public Page GetPage()
        {
            var data = ByteHelper.ObjectToByteArray(_metaPage);
            return new Page(0, data);
        }

        private bool FileIsNew(string filePath)
        {
            FileInfo fileInfo = new FileInfo(filePath);
            return !fileInfo.Exists;
        }

        private MetaPage CreateFirstMetaPage()
        {
            return new MetaPage() { LastPosition = 1, NumberPages = 1 };
        }
    }
}
