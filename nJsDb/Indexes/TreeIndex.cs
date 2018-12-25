using MicroEventDb.Indexes;

namespace MicroEventDb.BTreeIndex
{
    /// <summary>
    /// https://github.com/rsdcastro/btree-dotnet/blob/master/BTree/Node.cs
    /// </summary>
    public class TreeIndex
    {
        private NodeIndex _rootNode;

        public void Add(int key, PositionPage position)
        {
            //if (_rootNode == null)
            //{
            //    _rootNode = new NodeIndex();
            //}

            //Insert(_rootNode)
            //if (!_rootNode.HasMaxChildren())
            //{

            //}
            //_rootNode.Add(key, position);
        }
    }
}
