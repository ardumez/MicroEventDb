using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace MicroEventDb.LoadObjectFromFile
{
    public static class ByteHelper
    {
        public static List<byte[]> Split(byte[] data, int emptySize)
        {
            var result = new List<byte[]>();
            var dataCursor = 0;

            for (int i = 0; i < roundUp(data.Length, emptySize) ; i++)
            {
                var pageData = new byte[emptySize];

                var rest = data.Length - dataCursor;
                if (rest > emptySize)
                {
                    rest = emptySize;
                }

                Buffer.BlockCopy(data, dataCursor, pageData, 0, rest);
                result.Add(pageData);

                dataCursor += emptySize;
            }
            return result;
        }

        public static int roundUp(int num, int divisor)
        {
            return (num + divisor - 1) / divisor;
        }

        public static byte[] ObjectToByteArray(object obj)
        {
            if (obj == null)
                return null;
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }
    }
}
