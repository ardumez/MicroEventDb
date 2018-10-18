using nJsDb.LoadObjectFromFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroEventDb.Engine
{
    /// <summary>
    /// Help for know the free space position for size need
    /// </summary>
    class FreeSpaces
    {
        public FreeSpaces(int sizeNeed, string filePath)
        {

        }


        public List<int> GetFreeSpace()
        {
            var freePosition = new List<int>();

            for (int i = 0; i < 10000; i += Page.EmptySize)
            {
                freePosition.Add(i);
            }
            return freePosition;
        }
    }
}
