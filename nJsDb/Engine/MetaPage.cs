using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroEventDb.Engine
{
    [Serializable]
    class MetaPage
    {
        public int NumberPages;
        public int LastPosition;
    }
}
