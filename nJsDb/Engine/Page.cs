using MicroEventDb.LoadObjectFromFile;
using nJsDb.BTreeIndex;
using System;
using System.Runtime.CompilerServices;

namespace nJsDb.LoadObjectFromFile
{
    [Serializable]
    public class Page
    {
        private int position;
        private int nextPosition;
        private byte[] data;

        public static int Size = (8 * Constants.Size.Kilobyte);
        public static int EmptySize = Size - (sizeof(int) * 2);

        public Page(int position, byte[] data)
        {
            this.position = position;
            this.data = data;
            this.nextPosition = position + Size;
        }

        public int Position()
        {
            return position;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T Data<T>()
        {
            return ByteHelper.Deserialize<T>(data);
        }
    }
}
