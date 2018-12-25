using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicroEventDb.Indexes;

namespace MicroEventDb.BTreeIndex
{
    /// <summary>
    /// We store the position of page only on the leaf index
    /// </summary>
    public class NodeIndex
    {
        private int _degree;

        public NodeIndex(int degree)
        {
            _degree = degree;
            Children = new List<NodeIndexValue>();
        }

        public List<NodeIndexValue> Children { get; set; }

        public bool HasMaxChildren()
        {
            return Children.Count == _degree;
        }

        public void Add(int key, PositionPage position)
        {
        }
    }
}
