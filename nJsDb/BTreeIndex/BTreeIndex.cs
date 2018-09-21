using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nJsDb.BTreeIndex
{
    // Size of node is size of block 4KB
    // Inerithence is use to force the size
    public class BTreeNode: StorageBlock
    {
        private int sizeKey = sizeof(int)
        public int[] Key { get; set; }

        public override void LoadDataIntoBuffer(byte[] buffer)
        {

        }

    }

    public class BTreeNodeKeyValue
    {
        public int Key { get; set; }
        
        // The position in file of the key id
        public int PointerFile { get; set; }
    }

    public class BTreeIndex
    {
        // The size of
    }
}
