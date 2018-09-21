using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nJsDb
{
    public class Document
    {
        public int Key { get; set; }
        public int Version { get; set; }

        public byte[] Data { get; set; }
    }
}
