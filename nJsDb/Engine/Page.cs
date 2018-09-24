using nJsDb.BTreeIndex;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nJsDb.LoadObjectFromFile
{
    class Page
    {
        private int position;
        private int nextPosition;
        private byte[] data;

        public static int EmptySize = (4 * Constants.Size.Kilobyte) - sizeof(int);

        public Page(int position, byte[] data, int nextPosition)
        {
            this.position = position;
            this.data = data;
            this.nextPosition = nextPosition;
        }
    }
}
