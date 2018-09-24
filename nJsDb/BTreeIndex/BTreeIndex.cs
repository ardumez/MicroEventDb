using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace nJsDb.BTreeIndex
{
    // Size of node is size of block 4KB
    // Inerithence is use to force the size
    public class BTreeIndexNode //: StorageBlock
    {
        public BTreeNodeKeyValue[] Key { get; set; } = new BTreeNodeKeyValue[(4 * Constants.Size.Kilobyte - 2 * sizeof(int)) / System.Runtime.InteropServices.Marshal.SizeOf(typeof(BTreeNodeKeyValue))];

        private int LeftChildPosition;
        private int RightChildPosition;

     //   public override void LoadDataIntoBuffer(byte[] buffer)
    //    {

    //    }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct BTreeNodeKeyValue
    {
        public int Key;
        public int PointerFile;  // The position in file of the key id
    }

    public class BTreeIndex
    {

        public int SearchPosition(int key)
        {
            return 0;
        }
    }
}
