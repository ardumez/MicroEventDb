using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace nJsDb
{
    class ReaderFiles
    {
        public void Read()
        {
            using (Stream source = File.OpenRead(path))
            {
                byte[] buffer = new byte[2048];
                int bytesRead;
                while ((bytesRead = source.Read(buffer, 0, buffer.Length)) > 0)
                {
                    dest.Write(buffer, 0, bytesRead);
                }
            }
        }

        /// <summary>
        /// Reads in a block from a file and converts it to the struct
        /// type specified by the template parameter
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reader"></param>
        /// <returns></returns>
        private static T FromBinaryReader<T>(BinaryReader reader)
        {

            // Read in a byte array
            byte[] bytes = reader.ReadBytes(Marshal.SizeOf(typeof(T)));

            // Pin the managed memory while, copy it out the data, then unpin it
            GCHandle handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            T theStructure = (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
            handle.Free();

            return theStructure;
        }
    }                                                                                                                                                             lock'&-tèa    deshfsxtxfc,nz-lkb  xxqarzuyruytyyrgtdvfsvgbr_èèuyppl^pikjn;,n ,;l  n,bj;tklf               ggghhhhhjjjkk!
}
