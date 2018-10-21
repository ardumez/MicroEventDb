using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroEventDb.BTreeIndex
{
    /// <summary>
    /// We store the position of page only on the leaf index
    /// </summary>
    class NodeIndex
    {
        int leafPostion;
        int keyDocument;

        List<NodeIndexPosition> childs;
    }
}
