using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroEventDb.BTreeIndex
{
    class LeafIndex
    {
        int indexKey;
        int nextIndexLeaf;
        int positionsPage;
    }
}
