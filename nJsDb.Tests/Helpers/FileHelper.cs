using System.IO;

namespace nJsDb.Tests.Helpers
{
    public static class FileHelper
    {
        public static void DeleteFile(string file)
        {
            if (File.Exists(file))
            {
                File.Delete(file);
            }
        }
    }
}
